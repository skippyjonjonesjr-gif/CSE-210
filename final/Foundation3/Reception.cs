namespace EventPlanning
{
    public class Reception : Event
    {
        private string _rsvpEmail;

        public Reception(string title, string description, string date, string time, 
                         Address address, string rsvpEmail)
            : base(title, description, date, time, address, "Reception")
        {
            _rsvpEmail = rsvpEmail;
        }

        public override string GetFullDetails()
        {
            return base.GetFullDetails() + "\nRSVP Email: " + _rsvpEmail;
        }
    }
}