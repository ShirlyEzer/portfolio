package com.ex07;

import javax.servlet.ServletContext;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.*;

/**
 * Develop a simple servlet that prints out the list of all files and all folders the web application includes.
 * You should use the getResourcePaths method that was defined in ServletContext.
 */
@WebServlet(name = "ResourceServlet",urlPatterns = {"/ex08"})
public class ResourceServlet extends HttpServlet {

    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        PrintWriter out = response.getWriter();
        ServletContext servletContext = request.getServletContext();
        Set<String> resourcesPaths = servletContext.getResourcePaths("/");

        out.println("<html>");
        out.println("<body>");
        out.println("<head>");
        out.println("</head>");

        Iterator iterPaths = resourcesPaths.iterator();
        while (iterPaths.hasNext()) {
            out.println("File = " + (String) iterPaths.next());
            out.println("</br>");
        }
        out.println("</body>");
        out.println("</html>");
        out.flush();
    }
}
