SELECT user_id, spend, transaction_date
FROM ( SELECT user_id, spend, transaction_date, 
ROW_NUMBER() OVER (
PARTITION BY user_id ORDER BY transaction_date) AS rowNumber
FROM UBER) AS uber_trans 
WHERE rowNumber = 3;