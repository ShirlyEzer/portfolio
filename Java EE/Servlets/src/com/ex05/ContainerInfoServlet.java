package com.ex05;

import javax.servlet.ServletContext;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.io.PrintWriter;

/**
 * Develop a simple servlet that prints out to the screen the following information:
 * 1. The major version of the Java Servlet API the servlet container supports.
 * 2. The minor version of the Java Servlet API the servlet container supports.
 * 3. The name and the version of the servlet container.
 */

@WebServlet(name = "ContainerInfoServlet",urlPatterns = {"/ex05"})
public class ContainerInfoServlet extends HttpServlet {

    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        response.setContentType("text/html");
        PrintWriter out = response.getWriter();
        out.println("<html>");
        out.println("<body>");
        out.println("<head>");
        out.println("</head>");
        ServletContext context = request.getSession().getServletContext();
        out.println("Major version: " + context.getMajorVersion());
        out.println("</br>");
        out.println("Minor version: " + context.getMinorVersion());
        out.println("</br>");
        out.println("Servlet name and version: " + context.getServerInfo());
        out.println("</body>");
        out.println("</html>");
        out.flush();
    }
}
