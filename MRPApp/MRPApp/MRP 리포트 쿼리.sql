--1. PrcResult���� ���������� ���а����� �ٸ� (����)�÷����� �и�
SELECT p.SchIdx, p.PrcDate, 
		CASE p.PrcResult WHEN 1 THEN 1 ELSE 0 END AS PrcOK ,
		CASE p.PrcResult WHEN 0 THEN 1 ELSE 0 END AS PrcFail
	FROM Process AS p

--2. �հ� ���� ��� �������̺�

SELECT smr.SchIdx,smr.PrcDate, 
		SUM(smr.PrcOK) AS 'PrcOKAmount', SUM(smr.PrcFail) AS 'PrcFailAmount'
	FROM(
		SELECT p.SchIdx, p.PrcDate, 
			CASE p.PrcResult WHEN 1 THEN 1 ELSE 0 END AS PrcOK ,
			CASE p.PrcResult WHEN 0 THEN 1 ELSE 0 END AS PrcFail
		FROM Process AS p
	) AS smr
GROUP BY smr.SchIdx, smr.PrcDate

--3.0 ���ι�
SELECT * 
	FROM Schdules AS sch 
	INNER JOIN Process AS prc
	ON sch.SchIdx=prc.SchIdx
--3. 2�����(�������̺�)�� Schdules ���̺� �����ؼ� ���ϴ� ��� ����
SELECT sch.SchIdx, sch.PlantCode, sch.SchAmount, prc.PrcDate,
		prc.PrcOKAmount,prc.PrcFailAmount
	FROM Schdules AS sch
INNER JOIN (
SELECT smr.SchIdx,smr.PrcDate, 
		SUM(smr.PrcOK) AS 'PrcOKAmount', SUM(smr.PrcFail) AS 'PrcFailAmount'
	FROM(
		SELECT p.SchIdx, p.PrcDate, 
			CASE p.PrcResult WHEN 1 THEN 1 ELSE 0 END AS PrcOK ,
			CASE p.PrcResult WHEN 0 THEN 1 ELSE 0 END AS PrcFail
		FROM Process AS p
	) AS smr
GROUP BY smr.SchIdx, smr.PrcDate
) AS prc
ON sch.SchIdx=prc.SchIdx