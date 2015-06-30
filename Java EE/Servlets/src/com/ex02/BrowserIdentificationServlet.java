package com.ex02;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.Enumeration;

/**
 * Develop a Java servlet that identifies and prints out back to the screen "Internet Explorer"
 * if you use internet explorer or "Firefox" if you use firefox
 */

@WebServlet(name = "BrowserIdentificationServlet",urlPatterns = {"/ex02"})
public class BrowserIdentificationServlet extends HttpServlet {

    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        response.setContentType("text/html");
        PrintWriter out = response.getWriter();
        out.println("<html>");
        out.println("<body>");
        out.println("<head>");
        out.println("</head>");

        String headerValue = request.getHeader("user-agent");

        out.println(headerValue);
        out.println("</body>");
        out.println("</html>");
        out.flush();
    }
}
