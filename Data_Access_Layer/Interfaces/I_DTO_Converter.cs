using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Interfaces
{
    public interface I_DTO_Converter<DTO,Model>
    {
        Model DtoToModel(DTO dto);
        DTO ModelToDTO(Model model);
    }
}
