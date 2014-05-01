<?xml version="1.0" encoding="UTF-8"?>

<xsl:stylesheet version="1.0"
xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

  <xsl:template match="/">
    <html>
      <!--...........styles............................................................-->
      <head>
        <style media="screen" type="text/css">

          table{
          border-collapse: collapse;
          }

          td {
          border: 1px solid;
          padding: 2px 30px 2px 8px;
          font-size : medium;
          }

          .name {
          font-weight:bold ;
          width: 50%;
          }

          .place{
          padding-left: 20px;
          width: 50%;
          }
        </style>
      </head>
      <!--.......................body.....................................................-->
      <body>
        <h3>Простой отчет</h3>
        <table>
          <xsl:for-each select="company/ecologist">
            <tr>
              <td class ="name">
                <xsl:value-of select="name"/> 
              </td>
              <td></td>
            </tr>
            <xsl:for-each select="probe">
              <tr>
                <td class ="place">
                  <xsl:value-of select="place"/>
                </td>
                <td class ="date">
                  <xsl:value-of select="day"/>.<xsl:value-of select="month"/>.<xsl:value-of select="year"/>
                </td>
              </tr>
            </xsl:for-each>
          </xsl:for-each>
        </table>
      </body>
    </html>
  </xsl:template>

</xsl:stylesheet>
