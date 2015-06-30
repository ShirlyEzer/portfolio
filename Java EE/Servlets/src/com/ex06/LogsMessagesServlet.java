package com.ex06;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.Random;

/**
 * Calling the log method defined in GenericServlet we can write textual message
 * to the log file of our servlet container.
 * You should develop a simple servlet that creates an array that includes 10 random numbers,
 * sort them using the bubble sort alogirthm and print them back to the screen.
 * Your servlet should write log messages that describe each numbers swap that take place during the sort.
 */
@WebServlet(name = "LogsMessagesServlet",urlPatterns = {"/ex06"})
public class LogsMessagesServlet extends HttpServlet {

    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        int[] nums = new int[10];
        Random r = new Random();

        response.setContentType("text/html");
        PrintWriter out = response.getWriter();
        out.println("<html>");
        out.println("<body>");
        out.println("<head>");
        out.println("</head>");
        out.print("The array before the sort");
        out.print("</br>");
        for (int i = 0; i < nums.length; i++) {
            nums[i] = r.nextInt(100);
            out.print(nums[i] + " ");
        }
        out.print("</br>");
        out.print("</br>");
        boolean flag = true;   // set flag to true to begin first pass
        int temp;   //holding variable

        while ( flag )
        {
            flag = false;    //set flag to false awaiting a possible swap
            for(int j=0; j < nums.length -1; j++ )
            {
                if (nums[j] < nums[j+1])   // change to > for ascending sort
                {
                    this.log("swap: " + nums[j] + "," + nums[j+1]);
                    temp = nums[j];                //need to swap elements
                    nums[j] = nums[j+1];
                    nums[j+1] = temp;
                    flag = true;              //shows a swap occurred
                }
            }
        }
        out.print("The array after the sort");
        out.print("</br>");
        for (int i = 0; i < nums.length; i++) {
            out.print(nums[i] + " ");
        }
        out.println("</body>");
        out.println("</html>");
        out.flush();
    }
}
