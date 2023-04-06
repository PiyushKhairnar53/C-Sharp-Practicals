select CandidateId from Candidate where skill IN ('C#','MVC','SQL') group by 
CandidateId having count(CandidateId) >= 3 order by CandidateId asc;
