using System;
using AdminN;
using PostN;
using UserN;
using NotificationN;
using DatabaseN;

Posts post1 = new()
{
    id = staId.RId(),
    Content = "Salamlar",
    CreatingDateTime = DateTime.Now.ToString(),
    LikeCount = 0,
    ViewCount = 0
};
Posts post2 = new()
{
    id = staId.RId(),
    Content = "Hakuna Matata",
    CreatingDateTime = DateTime.Now.ToString(),
    LikeCount = 0,
    ViewCount = 0
};
Posts post3 = new()
{
    id = staId.RId(),
    Content = "Asante Sana Squash Banana,Nuqi Mimi Apana",
    CreatingDateTime = DateTime.Now.ToString(),
    LikeCount = 0,
    ViewCount = 0
};
Admin admin = new()
{
    id = 1,
    email = "admin@mail.ru",
    password = "admin",
    username = "admin",
    posts = new(),
    notfs = new()
};
admin.Addpost(post1);
admin.Addpost(post2);
admin.Addpost(post3);
User user = new()
{
    age = 18,
    email = "cemil123@gmail.com",
    id = 1,
    username = "cemil33",
    password = "cemil123"
};

AdminuserDB aud= new();
aud.AddAdmin(admin);
aud.AddUser(user);

int chs1 = 0;
int chs2 = 0;
int id =0;
string content;
string username;
string password;
int reg = 0;
int reg1 = 0;
while (true)
{
    Console.Clear();

    Console.WriteLine("Welcome");
    Console.WriteLine("1.Admin");
    Console.WriteLine("2.User");
    chs1 = int.Parse(Console.ReadLine());

    if (chs1 == 1)
    {
        while (true)
        {
            Console.Clear();

            Console.WriteLine("Username daxil edin");
            Console.WriteLine("0.Geri");            
            username = Console.ReadLine();
            if (username == "0") break;

            Console.WriteLine("Parol daxil edin");
            Console.WriteLine("0.Geri");
            password = Console.ReadLine();
            if (password == "0") break;

            foreach (var item in aud.admins)
            {
                if (username == item.username && password == item.password)
                {
                    reg++;
                }
            }

            if (reg == 1)
            {
                foreach (var item in aud.admins)
                {
                    if (username == item.username && password == item.password)
                    {
                        while (true)
                        {
                            Console.Clear();

                            Console.WriteLine("Welcome");
                            Console.WriteLine("1.Create new post.");
                            Console.WriteLine("2.See notification");
                            Console.WriteLine("0.Back");
                            chs2 = int.Parse(Console.ReadLine());

                            if (chs2 == 1)
                            {
                                Console.Clear();

                                Console.WriteLine("Movzunu daxil edin.");
                                content = Console.ReadLine();

                                item.posts.Add(new Posts() { id = staId.RId(), Content = content, CreatingDateTime = DateTime.Now.ToString(), LikeCount = 0, ViewCount = 0 });
                            }
                            else if (chs2 == 2)
                            {
                                while (true)
                                {
                                    Console.Clear();

                                    if (item.posts.Count == 0)
                                    {
                                        Console.WriteLine("Yeni bildirisiniz yoxdur");
                                        break;
                                    }
                                    else
                                    {
                                        while (true)
                                        {
                                            Console.Clear();

                                            foreach (var item1 in item.notfs)
                                            {
                                                Console.WriteLine($"(Id:{item1.id}) : ({item1.FrmUser})");
                                            }

                                            Console.WriteLine("Baxmaq istediyiniz Bildirisin id sini daxil edin");
                                            id = int.Parse(Console.ReadLine());

                                            foreach (var item3 in item.notfs)
                                            {
                                                if (id == item3.id)
                                                {
                                                    reg1++;
                                                }
                                            }

                                            if (reg1 > 0)
                                            {
                                                foreach (var item3 in item.notfs)
                                                {
                                                    if (id == item3.id)
                                                    {
                                                        Console.WriteLine($"Id: {item3.id}\nText:{item3.Text}\nData time:{item3.Datetime}\nFrom user: {item3.FrmUser}\nPost ID:{item3.post.id}");
                                                        item.notfs.Remove(item3);
                                                        Console.ReadLine();
                                                        break;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Xeta bele bir Id yoxdur");
                                                reg1 = 0;
                                                break;

                                            }
                                            reg1 = 0;
                                        }
                                    }
                                    break;
                                }
                            }
                            else break;
                        }
                    }
                }
            }

            else {
                Console.Clear();
                Console.WriteLine("Parol ve ya username yanlisdir.");
                Console.ReadLine();
                break; 
            }

        }
    }
    else if (chs1 == 2)
    {
        reg = 0;
        reg1 = 0;
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Username daxil edin");
            Console.WriteLine("0.Geri");
            username = Console.ReadLine();
            if (username == "0") break;
            Console.WriteLine("Parol daxil edin");
            Console.WriteLine("0.Geri");
            password = Console.ReadLine();
            if (password == "0") break;

            foreach (var item in aud.users)
            {
                if (username == item.username && password == item.password)
                {
                    reg++;
                }
            }

            if (reg > 0){

                foreach (var user1 in aud.users){

                    if (username == user1.username && password == user1.password) {

                        while (true) {
                            Console.Clear();

                            foreach (var item in aud.admins){

                                foreach (var item1 in item.posts){

                                    Console.WriteLine($"(Id:{item1.id})(Content:{item1.Content})");
                                }
                            }

                            Console.WriteLine("Baxmaq istediyiniz postun ID sini daxil edin");
                            Console.WriteLine("0.Geri");

                            id = int.Parse(Console.ReadLine());

                            if (id == 0) break;
                            foreach (var item in aud.admins){

                                foreach (var item1 in item.posts){

                                    if (item1.id == id){

                                        reg1++;
                                    }
                                }
                            }

                            if (reg1 > 0){
                                Console.Clear();

                                foreach (var item in aud.admins){

                                    foreach (var item1 in item.posts){

                                        if (item1.id == id){

                                            item1.ViewCount++;
                                            foreach (var item2 in aud.admins){
                                                item2.AddNotf(new Notf() { id = staId.RId(), FrmUser = user1.username, Datetime = DateTime.Now.ToString(), post = item1, Text = "Baxildi" });
                                            }
                                            Console.WriteLine($"ID:{item1.id}\nContent: {item1.Content}\nData time: {item1.CreatingDateTime}\nLike : {item1.LikeCount}  View : {item1.ViewCount}");
                                            Console.WriteLine("\n 1.Beyen");
                                            Console.WriteLine("\n 0.Geri");
                                            chs2 = int.Parse(Console.ReadLine());
                                            if (chs2 == 1)
                                            {
                                                foreach (var item2 in aud.admins)
                                                {
                                                    item1.LikeCount++;
                                                    item2.AddNotf(new Notf() { id = staId.RId(), FrmUser = user1.username, Datetime = DateTime.Now.ToString(), post = item1, Text = "Beyenildi" });
                                                }
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }
                                    }
                                }
                            }

                            else{
                                Console.WriteLine("Bu id de melumat yoxdur");
                            }
                        }
                    } 
                }
            }

            else
            {
                Console.Clear();
                Console.WriteLine("Xeta parol ve ya username sefdir");
                break;
            }
        }
        reg = 0;
        reg1 = 0;
    }
    
}

