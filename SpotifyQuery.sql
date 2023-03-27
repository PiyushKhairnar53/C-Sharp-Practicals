select top 1 ARTIST.* from ARTIST inner join(
select top 5 SONG.artist_id,COUNT(SONG.song_id) as song_appreances from SONG 
	inner join CHART
	on SONG.song_id = CHART.song_id
	where CHART.rank<=10 
	group by SONG.artist_id) SONG on ARTIST.artist_id = SONG.artist_id order by song_appreances desc
