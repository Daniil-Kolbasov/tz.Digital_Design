-- Сотрудник с максимальной заработной платой
SELECT TOP 1
    E.[NAME] 'Name',
    SALARY 'Salary'
FROM Employee AS E
LEFT JOIN Department AS D ON E.DEPARTMENT_ID = D.ID
ORDER BY SALARY DESC 

GO

-- Вывести одно число: максимальную длину цепочки 
-- руководителей по таблице сотрудников (вычислить 
-- глубину дерева).

SELECT TOP 1
    COUNT(CHIEF_ID) 'Maximum chain length'
FROM Employee
GROUP BY CHIEF_ID
ORDER BY COUNT(CHIEF_ID) DESC

GO

-- Отдел, с максимальной суммарной зарплатой сотрудников.

SELECT TOP 1
    [NAME] 'Name',
    SUM(SALARY) 'Maximum salary'
FROM Employee
GROUP BY [NAME]
ORDER BY SUM(SALARY) DESC

GO

-- Сотрудника, чье имя начинается на «Р» и 
-- заканчивается на «н».
SELECT
    [NAME] 'Name'
FROM Department
WHERE [NAME] LIKE 'Р%н'