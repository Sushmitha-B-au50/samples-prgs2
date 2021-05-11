using EFandLINQProject.Models;
using System;
using System.Linq;

namespace EFandLINQProject
{
    class Program
    {
        PostRepo postRepo;
        CommentRepo commentRepo;
        TweetContext context;

        Program()
        {
            context = new TweetContext();
            commentRepo = new CommentRepo(context);
            postRepo = new PostRepo(context);

        }

        void PrintPostWithComments()
        {
            var postWiseComment = context.Comments.ToList().GroupBy(c => c.PostId);
            foreach( var postComment in postWiseComment)
            {
                int id = postComment.Key;
                Post post = postRepo.Get(id);
                Printpost(post);
                Console.WriteLine("comment for this post");
                foreach(var comment in postComment)
                {
                    PrintComment(comment);
                }
                Console.WriteLine("----------------------------------");
            }
        }

        void PrintComment(Comment comment)
        {
            Console.WriteLine("Comment id" + comment.Id);
            Console.WriteLine(comment.CommentText);
        }

        void AddPost()
        {
            Console.WriteLine("please enter post category");
            string category = (Console.ReadLine());
            Console.WriteLine("please enter post Text");
            string text = (Console.ReadLine());
            Post post = new Post();
            post.Category = category;
            post.PostText = text;
            if (postRepo.Add(post))
                Console.WriteLine("This post is posted");
            else
                Console.WriteLine("This post is posted");
        }

        void PrintPosts()
        {
            var posts = postRepo.GetAll();
            if (posts != null)
                foreach (var item in posts.ToList())
                {
                    Printpost(item);
                }  
        }

        void Printpost(Post post)
        {
            Console.WriteLine("Post ID " + post.Id);
            Console.WriteLine("Post category " + post.Category);
            Console.WriteLine("Post  " + post.PostText);
        }

        void AddCommentToPost()
        {
            PrintPosts();
            int id = 0;
            Console.WriteLine("please enter the id for which you want to comment");
            id = Convert.ToInt32(Console.ReadLine());
            Post post = postRepo.Get(id);
            if(post != null)
            {
                Printpost(post);
                Comment comment = TakeComment(id);
                if (commentRepo.Add(comment))
                    Console.WriteLine("comment updated");
            }
        }

        private Comment TakeComment(int pid)
        {
            Comment comment = new Comment();
            comment.PostId = pid;
            Console.WriteLine("please enter comment");
            comment.CommentText = Console.ReadLine();
            return comment;
        }

        void UpdatePost()
        {
            PrintPosts();
            int choice = 0;
            do
            {
                Console.WriteLine("Pick your choice");
                Console.WriteLine("1. update  post text");
                Console.WriteLine("2. update  post category");
                Console.WriteLine("3. Exit");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        UpdatePostText();
                        break;
                    case 2:
                        UpdatePostcategory();
                        break;
                    case 3:
                        Console.WriteLine("exiting");
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;

                }
            } while (choice != 3) ;
        }
        void UpdatePostText()
        {
            int id = 0;
            Console.WriteLine("please enter the id for which you want to comment");
            id = Convert.ToInt32(Console.ReadLine());
            Post post = postRepo.Get(id);
            Console.WriteLine("please enter the post text");
            string newText = Console.ReadLine();
            post.PostText += newText;
            Console.WriteLine("post text updated");
        }
        void UpdatePostcategory()
        {
            int id = 0;
            Console.WriteLine("please enter the id for which you want to comment");
            id = Convert.ToInt32(Console.ReadLine());
            Post post = postRepo.Get(id);
            Console.WriteLine("please enter the post category");
            string newCategory = Console.ReadLine();
            post.Category += newCategory;
            Console.WriteLine("post category updated");
        }

        void UserInterface()
        {
            int choice = 0;
            do
            {
                Console.WriteLine("1. Create Post");
                Console.WriteLine("2. Add comment to post");
                Console.WriteLine("3. view all posts");
                Console.WriteLine("4. view post with comments");
                Console.WriteLine("5. Update post");
                Console.WriteLine("6. Exit");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddPost();
                        break;
                    case 2:
                        AddCommentToPost();
                        break;
                    case 3:
                        PrintPosts();
                        break;
                    case 4:
                        PrintPostWithComments();
                        break;                              
                    case 5:
                        UpdatePost();
                        break;
                    case 6:
                        Console.WriteLine("exiting");
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            } while (choice != 6);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello Tweet!");
            new Program().UserInterface();
        }
    }
}
