package com.company.chatSystem;

import javax.swing.*;
import java.awt.*;
import java.awt.event.*;
import java.io.IOException;
import java.net.Socket;

/**
 * Created by User on 22/11/2014.
 */
public class ClientGUI implements StringProducer, StringConsumer {

    private boolean isConnected;
    private JFrame jFrameChatClient;
    private JTextArea jTextAreaMessages;
    private JTextField jTextFieldWriteMassage;
    private JTextField jTextFieldIP;
    private JTextField jTextFieldUser;
    private JButton jButtonSend;
    private JButton jButtonConnect;
    private JButton jButtonDisconnect;
    private JLabel jLabelIP;
    private JLabel jLabelUser;
    private JPanel jPanelNorth;
    private JPanel jPanelCenter;
    private JPanel jPanelSouth;
    private ConnectionProxy connectionProxy;

    public ClientGUI()
    {
        jFrameChatClient = new JFrame("Chat Application");
        jFrameChatClient.setSize(1100,700);
        jFrameChatClient.setResizable(true);
        jFrameChatClient.setLayout(new BorderLayout());
        jPanelNorth = new JPanel(new FlowLayout());
        jPanelCenter = new JPanel(new FlowLayout());
        jPanelSouth = new JPanel(new FlowLayout());
        jTextAreaMessages = new JTextArea(35,70);
        jTextAreaMessages.setEnabled(false);
        jTextFieldUser = new JTextField(30);
        jTextFieldIP = new JTextField(30);
        jTextFieldWriteMassage = new JTextField(70);
        jTextFieldWriteMassage.setEnabled(false);
        jButtonConnect = new JButton("Connect");
        jButtonDisconnect = new JButton("Disconnect");
        jButtonDisconnect.setEnabled(false);
        jButtonSend = new JButton("Send");
        jButtonSend.setEnabled(false);
        jLabelUser = new JLabel("User:");
        jLabelIP = new JLabel("IP: ");
        isConnected = false;
    }

    public void go()
    {
        jFrameChatClient.setComponentOrientation(ComponentOrientation.LEFT_TO_RIGHT);
        jPanelNorth.add(jLabelUser);
        jPanelNorth.add(jTextFieldUser);
        jPanelNorth.add(jLabelIP);
        jPanelNorth.add(jTextFieldIP);
        jPanelNorth.add(jButtonConnect);
        jPanelNorth.add(jButtonDisconnect);
        jPanelCenter.add(jTextAreaMessages);
        jPanelSouth.add(jTextFieldWriteMassage);
        jPanelSouth.add(jButtonSend);
        jFrameChatClient.add(jPanelNorth,"North");
        jFrameChatClient.add(jPanelCenter,"Center");
        jFrameChatClient.add(jPanelSouth,"South");
        jFrameChatClient.setVisible(true);
        jButtonDisconnect.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                if (isConnected) {
                    isConnected = false;
                }
                jButtonConnect.setEnabled(true);
                jButtonDisconnect.setEnabled(false);
                jButtonSend.setEnabled(false);
                jTextFieldWriteMassage.setEnabled(false);
                jTextAreaMessages.setEnabled(false);
                connectionProxy.removeConsumer(connectionProxy);

                connectionProxy = null;
            }
        });
        jButtonSend.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                if(isConnected)
                {
                    connectionProxy.consume(jTextFieldWriteMassage.getText());
                    jTextFieldWriteMassage.setText("");
                }
            }
        });
        jButtonConnect.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                if (!isConnected) {
                    isConnected = true;
                }
                jButtonConnect.setEnabled(false);
                jButtonDisconnect.setEnabled(true);
                jButtonSend.setEnabled(true);
                jTextFieldWriteMassage.setEnabled(true);
                jTextAreaMessages.setEnabled(true);
                if (jTextFieldIP.getText() != null && jTextFieldUser.getText() != null) {
                    createConnectionProxy();
                }
            }
        });
        jFrameChatClient.addWindowListener(new WindowAdapter() {
            @Override
            public void windowClosing(WindowEvent e) {
                super.windowClosing(e);
                System.exit(0);
            }
        });

    }

    public static void main(String[] args) {

        SwingUtilities.invokeLater(new Runnable() {
            @Override
            public void run() {
                ClientGUI clientGUI = new ClientGUI();
                clientGUI.go();
            }
        });
    }

    @Override
    public void consume(String str) {
        //Write the messages which come from connectionProxy
        jTextAreaMessages.append(str + "\n");
    }

    @Override
    public void addConsumer(StringConsumer sc) {

    }

    @Override
    public void removeConsumer(StringConsumer sc) {
sc = null;
    }

    private void createConnectionProxy()
    {
        try {
            String ip = jTextFieldIP.getText();
            connectionProxy = new ConnectionProxy(new Socket(ip,1300));
            connectionProxy.addConsumer(this);
            connectionProxy.consume(jTextFieldUser.getText());
            connectionProxy.start();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}

