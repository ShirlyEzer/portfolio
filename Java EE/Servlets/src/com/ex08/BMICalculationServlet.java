package com.ex08;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.io.PrintWriter;

/**
 * Develop a simple servlet together with a compatible HTML form that allows the user to enter the height (cm)
 * and the weight (kg) and receive the BMI in return.
 */
@WebServlet(name = "BMICalculationServlet")
public class BMICalculationServlet extends HttpServlet {

    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        response.setContentType("text/html");
        PrintWriter out = response.getWriter();
        out.println("<html>");
        out.println("<body>");
        out.println("<head>");
        out.println("</head>");
        String weight = request.getParameter("weight");
        String height = request.getParameter("height");
        if(weight != null && height != null)
        {
            try
            {
                double w = Double.parseDouble(weight);
                double h = Double.parseDouble(height);
                double bmi = w/(h*h);
                out.println("You're weight is " + w);
                out.println("</br>");
                out.println("You're height is " + h);
                out.println("</br>");
                out.println("You're BMI is "+ bmi);
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
