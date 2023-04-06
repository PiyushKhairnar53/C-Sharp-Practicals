select month, count(distinct user_id) as active_users from
	(select user_id, event_type, month(event_date) as month, rank() 
		over (partition by user_id order by MONTH(event_date)) as mnths
		from FACEBOOK where MONTH(event_date) in (5,6) AND event_type 
		in ('like','comment','sign-in')) as users where users.mnths > 1 group by month
