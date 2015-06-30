package com.ex01;

import javax.servlet.ServletConfig;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.io.PrintWriter;

/**
 * Develop a Java servlet that can be initialized with two parameters (via web.xml file).
 * The first indicates the character to be used (either '@', '$', '*' or '+').
 * The second indicates which color (black, red, green, blue or yellow).

 The Java servlet dynamically draw a rectangle composed of characters of the selecter char.
 Each one of them should be in the specified color.
 */
@WebServlet(name = "InitializedColorfulRectangleServlet", urlPatterns = {"/ex01"})
public class InitializedColorfulRectangleServlet extends HttpServlet {

    private String character;
    private String color;

    public void init()
    {
        ServletConfig configuration = getServletConfig();
        character = configuration.getInitParameter("character");
        color = configuration.getInitParameter("color");
    }

    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        response.setContentType("text/html");
        PrintWriter out = response.getWriter();
        out.println("<html>");
        out.println("<body>");
        out.println("<head>");
        out.println("</head>");
        out.println("<font color=\""+color+"\">");
        for (int i = 0; i < 20; i++) {
            for (int j = 0; j < 20; j++) {
                out.print(character);
            }
            out.println("</br>");
        }
        out.println("</font>");
        out.println("</body>");
        out.println("</html>");
        out.flush();
    }
}
