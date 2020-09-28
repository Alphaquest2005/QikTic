select DATEADD(d,-2,getdate())
delete from TransactionBase where Time <= DATEADD(d,-2,getdate())
delete from batches where ClosingTime <= DATEADD(d,-2,getdate())
