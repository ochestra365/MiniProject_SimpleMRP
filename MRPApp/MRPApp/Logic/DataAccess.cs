using MRPApp.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Linq;

namespace MRPApp.Logic
{
    public class DataAccess
    {
        //셋팅 테이블에서 데이터 가져오기
        public static List<Settings> GetSettings()//internal 같은 어쎔블리안에서는 public으로 작동하니까 internal
        {
            List<Settings> settings;//Settings 테이블이랑 매칭이 되어 있다.
            using (var ctx = new MRPEntities())//SQL서버 직접 연결 시 커넥션스트링과 같은 역할을 한다고 보면 된다. MRPEntities는 연결과 같다
            {
                settings = ctx.Settings.ToList();//SELECT
            }
            //커넥션이 있을 때 커넥션을 닫아주는 역할을 한다. using을 하며 한 트랜잭션하에서 문제가 발생한다. 안정성이 좋다.
            //using을 안쓴다고 메모리 누수는 일어나지 않는다. 커넥션 연결의 자동해제를 위해서 using에서 해준다. 안정성을 한다.
            //socket할 때도 using을 쓰면 클로즈를 자동으로 해준다. 개발자가 close에 집중 안해도 된다.
            //메모리를 낭비하는 것을 using이 다 처리해준다. 클로즈에 신경쓰지 말자라는 의미로 using을 쓴다.
            //MRP엔티티프레임워크는 정말 안정성이 좋은 라이브러리이다.
            return settings;
        }

        public static int SetSettings(Settings item)//신규 버튼을 누를 때 클리어 및 코드를 다 쓸 수 있게 손봐줘야 한다.
        {
            using (var ctx = new MRPEntities())
            {
                ctx.Settings.AddOrUpdate(item);//INSERT or UPDATE
                return ctx.SaveChanges();//COMMIT
            }
        }

        internal static List<Schdules> GetSchedules()
        {
            List<Model.Schdules> list;
            using (var ctx = new MRPEntities())
                list = ctx.Schdules.ToList();
            return list;
        }

        public static int DelSettings(Settings item)//그리드에 올라간 데이터라서 정확하게 지울 수 없다. 엔티티프레임워크에서 DB와 다 연관되어 있다. 정확한 데이터를 지우기 위해 찾은 데이터를 지우는 것이다.
        {
            using (var ctx = new MRPEntities())
            {
                var obj = ctx.Settings.Find(item.BasicCode);//DB에서 데이터 검색한 뒤에 실제 데이터를 삭제한다.
                ctx.Settings.Remove(obj);//DELETE
                return ctx.SaveChanges();
            }
        }

        internal static int SetSchedule(Schdules item)
        {
            using (var ctx = new MRPEntities())
            {
                ctx.Schdules.AddOrUpdate(item);//INSERT or UPDATE
                return ctx.SaveChanges();//COMMIT
            }
        }

        internal static List<Model.Report> GetReportDatas(string startDate, string endDate, string plantCode)
        {
            var connString = ConfigurationManager.ConnectionStrings["MRPConnString"].ToString();
            var list = new List<Model.Report>();
            using(var conn=new SqlConnection(connString))//close는 using문이 해준다.
            {
                conn.Open();//필수 중요! @버바틴 스트링을 쓰면 바로 해결됨
                var sqlQuery = $@"SELECT sch.SchIdx, sch.PlantCode, sch.SchAmount, prc.PrcDate,
                                prc.PrcOKAmount,prc.PrcFailAmount
                            FROM Schdules AS sch
                        INNER JOIN(
                        SELECT smr.SchIdx, smr.PrcDate,
                                SUM(smr.PrcOK) AS 'PrcOKAmount', SUM(smr.PrcFail) AS 'PrcFailAmount'

                            FROM(
                                SELECT p.SchIdx, p.PrcDate,
                                    CASE p.PrcResult WHEN 1 THEN 1 ELSE 0 END AS PrcOK,
                                    CASE p.PrcResult WHEN 0 THEN 1 ELSE 0 END AS PrcFail

                                FROM Process AS p
                            ) AS smr
                        GROUP BY smr.SchIdx, smr.PrcDate
                        ) AS prc

                            ON sch.SchIdx = prc.SchIdx
                        WHERE sch.PlantCode = '{plantCode}'

                            AND prc.PrcDate BETWEEN '{startDate}' AND '{endDate}'";
                //결과값을 우리 것을 넣어서 사용한다.-->날짜로 검색되게 함.
                SqlCommand cmd = new SqlCommand(sqlQuery, conn);
                SqlDataReader reader = cmd.ExecuteReader();//reader는 그냥 배열이다. 그래서 우리 코드의 형태로 바꿔서 올려줘야 한다.

                while (reader.Read())
                {
                    var tmp = new Report
                    {
                        SchIdx = (int)reader["SchIdx"],
                        PlantCode = reader["PlantCode"].ToString(),
                        PrcDate = DateTime.Parse(reader["PrcDate"].ToString()),
                        SchAmount=(int)reader["SchAmount"],
                        PrcOKAmount=(int)reader["PrcOKAmount"],
                        PrcFailAmount=(int)reader["PrcFailAmount"]
                    };
                    list.Add(tmp);//이걸 왜 안 넣어 줬을까?
                }
            }
            return list;
        }

        internal static List<Process> GetProcess()
        {
            List<Model.Process> list;
            using (var ctx = new MRPEntities())
                list = ctx.Process.ToList();// SELECT

            return list;
        }
        internal static int SetProcess(Process item)
        {
            using (var ctx = new MRPEntities())
            {
                ctx.Process.AddOrUpdate(item);//INSERT|UPDATE
                return ctx.SaveChanges();//COMMIT
            }
        }
    }
}
