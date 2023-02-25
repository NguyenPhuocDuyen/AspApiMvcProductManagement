using BusinessObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class MemberDAO
    {
        private static bool IsAdmin(string emailUser, string passUser) {
            var builder = new ConfigurationBuilder()
                .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfiguration Configuration = builder.Build();
            string emailDefault = Configuration["Email"];
            string passwordDefault = Configuration["Password"];

            if (emailUser.Equals(emailDefault) && passUser.Equals(passwordDefault)) return true;

            return false;
        }

        public static Member CheckLogin(string emailUser, string passUser)
        {
            bool isAdmin = IsAdmin(emailUser, passUser);

            Member member = new Member();

            if (isAdmin) return new Member { Email = emailUser, Password = passUser};
            
            try
            {
                using (var context = new MyDbContext())
                {
                    member = context.Members.SingleOrDefault(x => x.Email == emailUser
                            && x.Password == passUser);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return member;
        }

        public static string CheckRole(string emailUser, string passUser) 
        {
            bool isAdmin = IsAdmin(emailUser, passUser);

            Member member = new Member();

            if (isAdmin) return "admin";

            Member m = CheckLogin(emailUser, passUser);

            if (m != null)
            {
                return "customer";
            }

            return "guest";
        }

        public static List<Member> GetMembers()
        {
            var members = new List<Member>();
            try
            {
                using (var context = new MyDbContext())
                {
                    members = context.Members.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return members;
        }

        public static Member FindMemberById(int memId)
        {
            Member p = new();
            try
            {
                using (var context = new MyDbContext())
                {
                    p = context.Members.SingleOrDefault(x => x.MemberId == memId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return p;
        }

        public static void SaveMember(Member member)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.Members.Add(member);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void UpdateMember(Member member)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.Entry<Member>(member).State =
                        Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteMember(Member member)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    var p = context.Members.SingleOrDefault(
                        c => c.MemberId == member.MemberId);
                    context.Members.Remove(p);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
