using General.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.Repository.Interface
{
    public interface IMemberRepository
    {
        bool Save(MemberModel model);
    }
}
