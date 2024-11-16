<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
    <xsl:output method="html" />
    <xsl:template match="/ScientificStaffSalaries">
        <html>
            <head>
                <link href="style.css" rel="stylesheet" type="text/css" />

				<style type = "text/css">
			            body {
                font-family: "Roboto", Arial, sans-serif;
                margin: 20px;
                background-color: #f5f7fa;
                color: #333;
            }

            table {
                width: 90%;
                margin: 20px auto;
                border-collapse: collapse;
                border: 1px solid #ddd;
                box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
                background-color: black;
            }

            th {
                background-color: #4CAF50;
                color: white;
                font-weight: bold;
                padding: 15px;
                text-align: center;
                text-transform: uppercase;
            }

            td {
                border: 1px solid #ddd;
                padding: 12px;
                text-align: center;
                font-size: 0.9em;
                color: #555;
            }

            tr:nth-child(even) {
                background-color: #f9f9f9;
            }

            tr:nth-child(odd) {
                background-color: #ffffff;
            }

            tr:hover {
                background-color: #f1f1f1;
                cursor: pointer;
            }

            tr {
                transition: background-color 0.3s ease;
            }

            caption {
                caption-side: top;
                text-align: center;
                font-size: 1.5em;
                font-weight: bold;
                margin: 15px;
                color: #333;
            }

            @media screen and (max-width: 768px) {
                table {
                    width: 100%;
                }

                th, td {
                    padding: 10px;
                    font-size: 0.8em;
                }
            }

			    </style>
            </head>
            <body>
                <table border="1">
                    <tr>
                        <th>Ім'я</th>
                        <th>Департамент</th>
                        <th>Сексія департамента</th>
                        <th>Позиція</th>
                        <th>Заробітня плата</th>
                        <th>Досвід роботи</th>
                    </tr>
                    <xsl:for-each select="StaffMember">
                        <tr>
                            <td><xsl:value-of select="Name" /></td>
                            <td><xsl:value-of select="Department" /></td>
                            <td><xsl:value-of select="DepartmentSection" /></td>
                            <td><xsl:value-of select="Position" /></td>
                            <td><xsl:value-of select="Salary" /></td>
                            <td><xsl:value-of select="Duration" /></td>
                        </tr>
                    </xsl:for-each>
                </table>
            </body>
        </html>
    </xsl:template>
</xsl:stylesheet>
