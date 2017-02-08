namespace ProAcqEF
{
    class EFTools
    {
        // insert
        public void ef_Insert(string date, string aTime, string rTime, string memo)
        {

            using (var pd = new ProAcqModel())
            {
                var pdSet = new PD_Entity
                {
                    PD_Date = date,
                    PD_AbsTime = aTime,
                    PD_RelTime = rTime,
                    PD_Memo = memo
                };

                pd.PD_Entities.Add(pdSet);
                pd.SaveChanges();

                pd.Dispose();
            }
        }

        // update
        // ...

        // delete
        // ...
    }
}
