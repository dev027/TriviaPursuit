using System.ComponentModel.DataAnnotations;

namespace Tp.Models.BaseModels
{
    public class BaseModelWithId : BaseModel
    {
        public BaseModelWithId()
        {
            
        }

        public BaseModelWithId(int id)
        {
            Id = id;
        }

        
        [Key]
        public int Id { get; set; }
    }
}