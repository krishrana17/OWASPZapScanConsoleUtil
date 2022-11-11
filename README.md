# Overview
This is the console application which will run ZAP (Zed Attack Proxy) via the command line. I have developed this application to run it on one of our on-premise server via task scheduler. Before running this app, please refer the appsettings.json file to change the configuration as per your need and which site you want to target etc. Here I assume that you have already installed "ZAP_2_12_0_windows" on your machine / server.

# So What is OWASP ZAP?
The OWASP - Open Web Application Security Project is an open, online community that creates methodologies, tools and guidance on how to deliver secure web applications. OWASP ZAP (Zed Attack Proxy) is a free open-source tool which is easy to setup and use and one of the world’s most popular free security tools and is actively maintained by some volunteers. It can help to find security vulnerabilities in your web applications.

# Download OWASP
ZAP is platform independent. So you can install it on Windows, Linux or Mac OS. You need JRE 8+ (Java Runtime Environment) installed on your machine.
You can download it from here - https://www.zaproxy.org/download/

# How it works
ZAP is working as a "man in the middle". While you navigate through all the features of the website, it captures all actions. Then it attacks the website with known techniques to find security vulnerabilities.

# References
https://www.zaproxy.org/docs/desktop/addons/quick-start/cmdline/

https://docs.oracle.com/goldengate/1212/gg-winux/GDRAD/java.htm#BGBFJHAB
