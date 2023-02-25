using BusinessObject;
using DataAccess.DAO;
using DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class MemberRepository : IMemberRepository
    {
        public Member GetMemberById(int id) => MemberDAO.FindMemberById(id);
        public void SaveMember(Member member) => MemberDAO.SaveMember(member);
        public void UpdateMember(Member member) => MemberDAO.UpdateMember(member);
        public void DeleteMember(Member member) => MemberDAO.DeleteMember(member);

        public List<Member> GetMembers() => MemberDAO.GetMembers();

        public Member CheckLogin(string emailUser, string passUser) => MemberDAO.CheckLogin(emailUser, passUser);
        public string CheckRole(string emailUser, string passUser) => MemberDAO.CheckRole(emailUser, passUser);}
}
