using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.IRepository
{
    public interface IMemberRepository
    {
        void SaveMember(Member member);
        Member GetMemberById(int id);
        void DeleteMember(Member member);
        void UpdateMember(Member member);
        List<Member> GetMembers();

        Member CheckLogin(string emailUser, string passUser);
        string CheckRole(string emailUser, string passUser);
    }
}
