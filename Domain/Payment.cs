namespace Domain
{
    public class Payment
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public string Descripion { get; set; }
        public bool IsAccepted { get; set; }
        #region Issuer
        //public int IssuerId {  get; set; }
        public User Issuer { get; set; }
        #endregion
        #region Recipient
        //public int RecipientId { get; set; }
        public User Recipient { get; set; }
        #endregion
        #region Group
        //public int GroupId { get; set; }
        public Group Group { get; set; }
        #endregion
    }
}
