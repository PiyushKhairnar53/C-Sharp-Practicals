SELECT transaction_date, user_id, 
  product_id, 
  RANK() OVER (
    PARTITION BY user_id 
    ORDER BY transaction_date DESC) AS days_rank 
  FROM WALMART;