package il.ac.hit.currencies;

import org.apache.log4j.*;
import javax.swing.*;
import java.awt.*;
import java.awt.event.*;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.List;

/**
 * <code>ClientGUI</code> is a view of the currency application.
 *
 * @author Shirly
 * @author Oreyan
 */
public class ClientGUI implements ICurrencyUpdater {

    /**
     * @param jFrame - JFrame Represents the main frame of our program carries all our panels CurrencyExchangeModel represents the model part of our project
     * @param jComboBoxSource - JComboBox to choose the source currency
     * @param jComboBoxDestination - JComboBox to choose the currency we want to convert to
     * @param jTextFieldAmount - JTextField to insert the amount which will be converted
     * @param jLabelDateTime - JLabel presenting the last update
     * @param jLabelResult - JLabel to display the result
     * @param jLabelSource - JLabel to display "Source: "
     * @param jLabelDestination - JLabel to display "Destination: "
     * @param jLabelAmountToConvert - JLabel to display "Amount to convert: "
     * @param jButtonConvert - JButton When pressed activates the convert method of our model
     * @param jPanelNorth - JPanel carriers the components of amount to be converted
     * @param jPanelCenter - JPanel carriers the jPanelCenterNorth and jPanelCenterSouth
     * @param jPanelCenterNorth - JPanel Carries the components of source and destination currencies
     * @param jPanelCenterSouth - JPanel Carries the jTableUpToDateCurrencies
     * @param jPanelSouth - JPanel carriers the jPanelSouthNorth and jPanelSouthSouth
     * @param jPanelSouthNorth - JPanel carriers the jButtonConvert
     * @param jPanelSouthSouth - JPanel carriers the jLabelResult
     * @param currencyModel - ICurrencyModel which holds the model of the application
     * @param jTableUpToDateCurrencies - JTable that represents the data of currencies
     * @param currencyList - List that holds the data of the currencies
     * @param logger - add log messages to logFile.log and to the console
     */

    private JFrame jFrame;
    private JComboBox jComboBoxSource;
    private JComboBox jComboBoxDestination;
    private JTextField jTextFieldAmount;
    private JLabel jLabelResult;
    private JLabel jLabelSource;
    private JLabel jLabelDestination;
    private JLabel jLabelAmountToConvert;
    private JButton jButtonConvert;
    private JPanel jPanelNorth;
    private JPanel jPanelCenter;
    private JPanel jPanelCenterNorth;
    private JPanel jPanelCenterSouth;
    private JPanel jPanelSouth;
    private JPanel jPanelSouthNorth;
    private JPanel jPanelSouthSouth;
    private ICurrencyModel currencyModel;
    private JTable jTableUpToDateCurrencies;
    private JLabel jLabelDateTime;
    private List<Currency> currencyList;
    public static Logger logger;

    /**
     * Creates a new ClientGUI for the currency application
     */
    public ClientGUI() {
        logger = Logger.getLogger(ClientGUI.class);
        PropertyConfigurator.configure("logconfig");

        //creating model
        currencyModel = new CurrencyModel(this);
        logger.info("Model is created");

        try {
            currencyList = currencyModel.getCurrenciesData();
        } catch (CurrenciesPlatformException e) {
            try {
                Thread.sleep(3000);
                currencyList = currencyModel.getCurrenciesData();
            } catch (InterruptedException e1) {
                e1.printStackTrace();
            }
            catch (CurrenciesPlatformException e2)
            {
                JOptionPane.showMessageDialog(jFrame,
                        e.getMessage(),
                        "Currency Error",
                        JOptionPane.ERROR_MESSAGE);
                logger.error("Currencies data was not created due to : " + e.getMessage());
            }
        }
        //creating gui components
        jFrame = new JFrame("Currency App");
        jFrame.setSize(450,450);
        jComboBoxSource = new JComboBox(getCurrenciesArray());
        jComboBoxDestination = new JComboBox(getCurrenciesArray());
        setTable();
        jTextFieldAmount = new JTextField(15);
        jLabelResult = new JLabel("0");
        jLabelSource = new JLabel("Source: ");
        jLabelDestination = new JLabel("Destination: ");
        jLabelAmountToConvert = new JLabel("Amount to convert: ");
        SimpleDateFormat dateFormat = new SimpleDateFormat("yyyy/MM/dd");
        Date date = new Date();
        jLabelDateTime = new JLabel("Last Update: " + dateFormat.format(date));
        jButtonConvert = new JButton("Convert!");
        //creating panels
        jPanelNorth = new JPanel();
        jPanelCenter = new JPanel();
        jPanelCenterNorth = new JPanel();
        jPanelCenterSouth = new JPanel();
        jPanelSouth = new JPanel();
        jPanelSouthNorth = new JPanel();
        jPanelSouthSouth = new JPanel();
    }

    /**
     * <code>go()</code> will sets all the components in the frame and make it visible to the client.
     */
    public void go()
    {
        jTextFieldAmount.setText("1");
        //setting the jFrame
        jFrame.setLayout(new BorderLayout());
        jFrame.add(jPanelNorth, "North");
        jFrame.add(jPanelCenter,"Center");
        jFrame.add(jPanelSouth,"South");
        //setting the outer panels
        jPanelNorth.setLayout(new FlowLayout());
        jPanelNorth.add(jLabelAmountToConvert);
        jPanelNorth.add(jTextFieldAmount);
        jPanelCenter.setLayout(new BorderLayout());
        jPanelCenter.add(jPanelCenterNorth, "North");
        jPanelCenter.add(jPanelCenterSouth, "South");
        jPanelSouth.setLayout(new BorderLayout());
        jPanelSouth.add(jPanelSouthNorth, "North");
        jPanelSouth.add(jPanelSouthSouth, "South");
        //setting the inner panels
        jPanelSouthNorth.setLayout(new FlowLayout());
        jPanelSouth.add(jButtonConvert, "Center");
        jPanelSouthSouth.setLayout(new FlowLayout());
        jPanelSouthSouth.add(jLabelResult);
        jPanelCenterNorth.setLayout(new FlowLayout());
        jPanelCenterNorth.add(jLabelSource);
        jPanelCenterNorth.add(jComboBoxSource);
        jPanelCenterNorth.add(jLabelDestination);
        jPanelCenterNorth.add(jComboBoxDestination);
        jPanelCenterSouth.setLayout(new FlowLayout());
        jPanelCenterSouth.add(jTableUpToDateCurrencies);
        jPanelSouthNorth.add(jLabelDateTime);
        jFrame.setVisible(true);
        //setting the window listener to be able to be closed
        jFrame.addWindowListener(new WindowAdapter() {
            @Override
            public void windowClosing(WindowEvent e) {
                logger.info("User exit the application");
                super.windowClosing(e);
                System.exit(0);
            }
        });
        //setting the button convert listener to run the convert method
        jButtonConvert.addMouseListener(new MouseAdapter() {
            @Override
            public void mouseClicked(MouseEvent mouseEvent) {
                Currency source = null;
                Currency destination = null;
                double sumCalculated = 0;
                logger.info("User is trying to convert money");
                try {
                    sumCalculated = currencyModel.convert
                            (getJTextFieldAmountValue(), (String)jComboBoxSource.getSelectedItem(),(String)jComboBoxDestination.getSelectedItem());
                    jLabelResult.setText(Double.toString(sumCalculated));
                } catch (CurrenciesPlatformException e) {
                    JOptionPane.showMessageDialog(jFrame,
                            e.getMessage(),
                            "Currency Error",
                            JOptionPane.ERROR_MESSAGE);
                    logger.error("Convert method failed to execute error: " + e.getMessage());
                }
                logger.info("Convert method executed");
            }
        });
    }
    /**
     * Gets the amount of money to be converted from the jTextFieldAmount and parse it to double.
     *
     * @return Amount of money to convert currencies.
    **/
    private double getJTextFieldAmountValue()
    {
        double amount = 0;
        try {
            amount = Double.parseDouble(jTextFieldAmount.getText());
        } catch (NumberFormatException e) {
            JOptionPane.showMessageDialog(jFrame,
                    "Please enter only numbers in the text field",
                    "Currency Error",
                    JOptionPane.ERROR_MESSAGE);
            logger.error("User didn't enter only numbers in the text field");
            jTextFieldAmount.setText("1");
        }

        return amount;
    }

    /**
     * Creates an array for describing the currencies in the application
     *
     * @return Array of string describing the currencies
     */
    private String[] getCurrenciesArray()
    {
        String[] currencyArray = null;
        int i=0;

        if(currencyList == null)
        {
            try {
                Thread.sleep(1);
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }
        else
        {
            currencyArray = new String[currencyList.size()];
        }

        //going through the list and adding the concat string of the coin name string and the country string
        for (Currency currency : currencyList)
        {
            currencyArray[i] = currency.getCoinName() + " " + currency.getCountry();
            i++;
        }
        return currencyArray;
    }

    /**
     * Sets the JTable in GUI with the currencies from the list
     */
    private void setTable()
    {
        logger.info("Setting the table of currencies for the first time");
        //setting the table and filling it with data
        jTableUpToDateCurrencies = new JTable(currencyList.size()+1,4);
        jTableUpToDateCurrencies.setValueAt("Coin Name:",0,0);
        jTableUpToDateCurrencies.setValueAt("Unit:",0,1);
        jTableUpToDateCurrencies.setValueAt("Rate:",0,2);
        jTableUpToDateCurrencies.setValueAt("Country:",0,3);
        /*
         * going through the list and setting the table
         */
        for (int i = 0; i < currencyList.size(); i++) {
            jTableUpToDateCurrencies.setValueAt(currencyList.get(i).getCoinName(),i+1,0);
            jTableUpToDateCurrencies.setValueAt(currencyList.get(i).getUnit(),i+1,1);
            jTableUpToDateCurrencies.setValueAt(currencyList.get(i).getRate(),i+1,2);
            jTableUpToDateCurrencies.setValueAt(currencyList.get(i).getCountry(),i+1,3);
        }
    }

    /**
     * Updating the content of the jTable, only the rate of each currency in the list.
     *
     * @param currencyList an updated list of coins
     */
    @Override
    public void updateCurrencyData(List<Currency> currencyList) {

        this.currencyList = currencyList;
        /*
         * going through the list and updating only column 2 in the table
         */
        for (int i = 1; i < currencyList.size(); i++) {
            jTableUpToDateCurrencies.setValueAt(currencyList.get(i).getRate(),i,2);
        }
        jLabelDateTime.setText("Last Update: " + currencyModel.getLastUpdate());
        logger.info("Table updated");
    }

    /**
     * Running the Currencies Application
     */
    public static void main(String[] args) {
        SwingUtilities.invokeLater(new Runnable() {
            @Override
            public void run() {

                ClientGUI c = new ClientGUI();
                logger.info("Gui is loaded");
                c.go();
                logger.info("Application is running");
            }
        });
    }
}
