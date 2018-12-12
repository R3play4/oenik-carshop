import java.io.IOException;
import java.io.PrintWriter;
import java.util.Random;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import static com.sun.org.apache.xalan.internal.xsltc.compiler.util.Type.Int;

@WebServlet (name = "RandomPriceGenerator", urlPatterns = {"/RandomPriceGenerator"})
public class RandomPriceGenerator extends HttpServlet{

    protected void processRequest(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        response.setContentType("text/xml;charset=UTF8");
        PrintWriter out = response.getWriter();
        String documentType = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";

        out.println(documentType + "<cars>");
        String carName = request.getParameter("carname");

        for (int i = 0; i < 5 ; i++){
            out.println("<cardata>");
            int price = Integer.parseInt(request.getParameter("price"));
            int randPrice = new Random().nextInt(price);

            while(Math.abs(randPrice - price) > 100 ){
                randPrice = new Random().nextInt(price);
            }

            out.println("<name>" + carName + "</name>");
            out.println("<price>" + randPrice + "</price>");
            out.println("</cardata>");
        }
        out.println("</cars>");
    }

    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        processRequest(request, response);
    }
}
