select INP.page_id from INSTAGRAMPAGES INP LEFT JOIN PAGELIKES PGL ON 
INP.page_id = PGL.page_id where PGL.page_id is NULL order by page_id
