using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ThomasWebsite.Models;

namespace ThomasWebsite.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        public ActionResult Index()
        {
            IEnumerable<BlogModel> blogs;
            using (var db = new BlogContext())
            {
                blogs = db.Blogs
                    //.Where(b => b.IsPublished)
                        .OrderBy(b => b.PublishDate)
                        .ToArray();
            }

            return View(blogs);
        }

        public ActionResult Create()
        {
            if (Request.HttpMethod == "POST")
            {
                var title = Request["Title"].ToString();
                var author = Request["Author"].ToString();
                var publishDate = DateTime.Now;
                var contents = Request["Contents"].ToString();
                var isPublished = Request["IsPublished"].ToString();

                using (var db = new BlogContext())
                {
                    var newBlog = new BlogModel();
                    newBlog.Title = title;
                    newBlog.Author = author;
                    newBlog.PublishDate = publishDate;
                    newBlog.Contents = contents;
                    //newBlog.IsPublished = Convert.ToBoolean(isPublished);

                    db.Blogs.Add(newBlog);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Edit(int Id)
        {
            if (Request.HttpMethod == "POST")
            {
                var title = Request["Title"].ToString();
                var author = Request["Author"].ToString();
                var publishDate = DateTime.Now;
                var contents = Request["Contents"].ToString();
                var isPublished = Request["IsPublished"].ToString();

                using (var db = new BlogContext())
                {
                    var newBlog = db.Blogs
                                .Where(b => b.Id == Id)
                                .First();

                    newBlog.Title = title;
                    newBlog.Author = author;
                    newBlog.PublishDate = publishDate;
                    newBlog.Contents = contents;
                    //newBlog.IsPublished = Convert.ToBoolean(isPublished);

                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            else
            {
                BlogModel blog;
                using (var db = new BlogContext())
                {
                    blog = db.Blogs
                            .Where(b => b.Id == Id)
                            .FirstOrDefault();
                }

                if (blog == null)
                {
                    return HttpNotFound();
                }

                return View(blog);
            }
        }

        public ActionResult Delete(int Id)
        {
            if (Request.HttpMethod == "POST")
            {
                using (var db = new BlogContext())
                {
                    var blogToDelete = db.Blogs
                                    .Where(b => b.Id == Id)
                                    .First();

                    db.Blogs.Remove(blogToDelete);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            else
            {
                BlogModel blog;
                using (var db = new BlogContext())
                {
                    blog = db.Blogs
                            .Where(b => b.Id == Id)
                            .FirstOrDefault();
                }

                if (blog == null)
                {
                    return HttpNotFound();
                }

                return View(blog);
            }
        }

        public ActionResult Details(int Id)
        {
            BlogModel blog;
            using (var db = new BlogContext())
            {
                blog = db.Blogs
                        .Where(b => b.Id == Id)
                        .FirstOrDefault();
            }

            if (blog == null)
            {
                return HttpNotFound();
            }

            return View(blog);
        }
    }
}