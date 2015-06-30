package com.ex03;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.io.PrintWriter;

/**
 * Develop a Java servlet that is called from an HTML form and receives two values:
 * the width and the height of a given rectangle.
 * The servlet should calculate and return back to the screen the rectangle peremiter and area.
 */
@WebServlet(name = "RectangleAreaServlet",urlPatterns = {"/ex03"})
public class RectangleAreaServlet extends HttpServlet {

    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        //response.setContentType("text/html");
        response.addHeader("Content-Type","text/html");
        response.addHeader("Content-Type","text/plain");
        PrintWriter out = response.getWriter();
        out.println("<html>");
        out.println("<body>");
        out.println("<head>");
        out.println("</head>");
        String width = request.getParameter("width");
        String height = request.getParameter("height");
        if(width != null && height != null)
        {
            try
            {
                double w = Double.parseDouble(width);
                double h = Double.parseDouble(height);
                double perimeter = 2*(w+h);
                double area = w*h;
                out.println("This is a calc for a rectangle :)");
                out.println("</br>");
                out.println("   rectangle width=" + w);
                out.println("</br>");
                out.println("   rectangle height=" + h);
                out.println("</br>");
                out.println("   perimeter="+perimeter);
                out.println("</br>");
                out.println("   area="+area);
            }
            catch (NumberFormatException e)
            {
                out.println("error in casting the parameters given");
            }
        }
        else
        {
            out.println("error in the parameters given");
        }
        out.println("</body>");
        out.println("</html>");
        out.flush();
    }
}
