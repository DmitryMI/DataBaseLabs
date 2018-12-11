
DROP TABLE t1
CREATE TABLE t1(
	empl VARCHAR(50),
	type_v INT,
	data_t1 DATE
)

INSERT INTO t1(type_v,empl,data_t1)
VALUES(1,'Ivanov','2018-01-11'),
(1,'Ivanov','2018-01-12'),
(1,'Ivanov','2018-01-13'),
(1,'Ivanov','2018-01-14'),
(1,'TEST','2018-02-12'),
(2,'TEST','2018-03-03'),
(2,'TEST','2018-03-22'),

(1,'TEST','2018-01-12'),
(1,'TEST','2018-01-13'),
(1,'TEST','2018-01-14')


SELECT
  R.empl AS Employee_name,
  R.type_v AS vacation_type,
  MIN(R.data_t1) AS 'From',
  MAX(R.data_t1) AS 'To'
FROM (
SELECT DISTINCT
    data_t1 AS data_t1,
	empl AS empl,
	type_v AS type_v,
	DATEADD(day, -DENSE_RANK() OVER (ORDER BY data_t1), data_t1) AS grp
    FROM t1
) AS R
GROUP BY R.empl, R.type_v, R.grp
