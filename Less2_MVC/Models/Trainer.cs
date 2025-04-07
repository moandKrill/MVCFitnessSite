using System.ComponentModel.DataAnnotations;

namespace Less2_MVC.Models
{
    public class Trainer
    {
        [Key]
        public int id_trainer { get; set; }
        public string name { get; set; }
        public string telephone { get; set; }
        public string trainer_info { get; set; }
        public string photo_url { get; set; }

        //public Trainer(string name, string telephone, string trainer_info, string photo_url)
        //{
        //    this.name = name;
        //    this.telephone = telephone;
        //    this.trainer_info = trainer_info;
        //    this.photo_url = photo_url;
        //}
    }
}
