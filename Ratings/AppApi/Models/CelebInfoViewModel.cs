namespace AppApi.Models
{
    public class CelebInfoViewModel
    {
        private string name;
        private int totalFollowers;
        private string description1;
        private string description2;
        private string description3;
        private string img;
        private string url;
        public List<Social> socail = null;
        public CelebInfoViewModel(string name,
            int followers,
            string desc1,
            string desc2, string desc3, string img, string url)
        {
            this.name = name;
            this.totalFollowers = followers;
            this.description1 = desc1;
            this.description2 = desc2;
            this.description3 = desc3;
            this.img = img;
            this.url = url;
            

        }
        public CelebInfoViewModel() { }
        public string Name { get { return name; } set { name = value; } }
        public int TotalFollowers { get { return totalFollowers; } set { totalFollowers = value; } }
        public string Description1 { get { return description1; } set { description1 = value; } }
        public string Description2 { get { return description2; } set { description2 = value; } }
        public string Description3 { get { return description3; } set { description3 = value; } }
        public string Img { get { return img; } set { img = value; } }
        public string Url { get { return url; } set { url = value; } }
       
        
        
    }

    public class Social
    {
        private string? name;
        private string? url;
        public Social(string name, string url) 
        { 
            this.name = name;
            this.url = url;
        }
        public Social() { }
        public string Name { get { return name; } set { name = value; } }
        public string Url { get { return url; }set { url = value; } }
    }
}
