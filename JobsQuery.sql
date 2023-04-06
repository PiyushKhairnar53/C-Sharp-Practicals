select COUNT(distinct company_id) from(select company_id,title,description from 
JOBS group by company_id,title,description having (count(company_id)>1 AND 
count(title) > 1 AND count(description)>1))JOBS
