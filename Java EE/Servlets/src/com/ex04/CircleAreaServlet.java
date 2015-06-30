package com.ex04;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.io.PrintWriter;

/**
 * Develop a Java servlet that is called from an HTML form and receives one value: the radius of a given circle.
 * The servlet should calculate and return back to the screen the circle peremiter and area.
 */
@WebServlet(name = "CircleAreaServlet",urlPatterns = {"/ex04"})
public class CircleAreaServlet extends HttpServlet {

    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        response.setContentType("text/html");
        PrintWriter out = response.getWriter();
        out.println("<html>");
        out.println("<body>");
        out.println("<head>");
        out.println("</head>");
        String radius = request.getParameter("radius");
        if(radius != null)
        {
            try
            {
                double r = Double.parseDouble(radius);
                double perimeter = 2*Math.PI*r;
                double area = Math.PI*r*r;
                out.println("This is a calc for a circle :)");
                out.println("</br>");
                out.println("   circle radius=" + r);
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
