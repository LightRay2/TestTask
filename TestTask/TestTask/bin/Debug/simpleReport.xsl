<?xml version="1.0" encoding="UTF-8"?>

<xsl:stylesheet version="1.0"
xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

  <xsl:template match="/">
    <html>
      <body>
        <h2>Простой отчет</h2>
        <table>
          <xsl:for-each select="company/ecologist">
            <tr>
              <td>
                <b>  <xsl:value-of select="name"/>   </b>
              </td>
              <td></td>
            </tr>
            <xsl:for-each select="probe">
              <tr>
                <td>
                  <xsl:value-of select="place"/>
                </td>
                <td>
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
