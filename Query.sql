use Trackify;

select * 
from Tasks t
join Comments c
on t.id = c.TaskId;