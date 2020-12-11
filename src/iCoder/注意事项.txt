1. Session["UserId"];
2. AddTime直接用的GetDate()， 只有在插入时更新；
3. update方法第一个参数是ID； 固定
4. 删除方法中，如果再用的不能删除，方法要重写， 加入判断条件；
5. 