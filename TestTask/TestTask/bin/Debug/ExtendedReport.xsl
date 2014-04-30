<?xml version="1.0" encoding="UTF-8"?>

<xsl:stylesheet version="1.0"
xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

  <xsl:template match="/">
    <html>
      <body>
        <h2>Расширенный отчет</h2>
        <table>
          <tr>
            <td></td>
            <td>янв</td>
            <td>фев</td>
            <td>мар</td>
            <td>апр</td>
            <td>май</td>
            <td>июнь</td>
            <td>июль</td>
            <td>авг</td>
            <td>сен</td>
            <td>окт</td>
            <td>ноя</td>
            <td>дек</td>
          </tr>
          <xsl:for-each select="company/ecologist">
            <tr>
              <td>
                  <xsl:value-of select="name"/>
              </td>
              <!-- ............................1- 4............................................-->
              <xsl:choose>
                <xsl:when test ="count(probe[month='01'])=0"><td>-</td></xsl:when>
                <xsl:otherwise>
                  <td> <xsl:value-of select="count(probe[month='01'])"/> </td>
                </xsl:otherwise>
              </xsl:choose>
              <xsl:choose>
                <xsl:when test ="count(probe[month='02'])=0"><td>-</td></xsl:when>
                <xsl:otherwise>
                  <td> <xsl:value-of select="count(probe[month='02'])"/> </td>
                </xsl:otherwise>
              </xsl:choose>
              <xsl:choose>
                <xsl:when test ="count(probe[month='03'])=0"><td>-</td></xsl:when>
                <xsl:otherwise>
                  <td> <xsl:value-of select="count(probe[month='03'])"/> </td>
                </xsl:otherwise>
              </xsl:choose>
              <xsl:choose>
                <xsl:when test ="count(probe[month='04'])=0"><td>-</td></xsl:when>
                <xsl:otherwise>
                  <td> <xsl:value-of select="count(probe[month='04'])"/> </td>
                </xsl:otherwise>
              </xsl:choose>
              
              <!-- ..........................5- 8......................................-->
              <xsl:choose>
                <xsl:when test ="count(probe[month='05'])=0"><td>-</td></xsl:when>
                <xsl:otherwise>
                  <td> <xsl:value-of select="count(probe[month='05'])"/> </td>
                </xsl:otherwise>
              </xsl:choose>
              <xsl:choose>
                <xsl:when test ="count(probe[month='06'])=0"><td>-</td></xsl:when>
                <xsl:otherwise>
                  <td> <xsl:value-of select="count(probe[month='06'])"/> </td>
                </xsl:otherwise>
              </xsl:choose>
              <xsl:choose>
                <xsl:when test ="count(probe[month='07'])=0"><td>-</td></xsl:when>
                <xsl:otherwise>
                  <td> <xsl:value-of select="count(probe[month='07'])"/> </td>
                </xsl:otherwise>
              </xsl:choose>
              <xsl:choose>
                <xsl:when test ="count(probe[month='08'])=0"><td>-</td></xsl:when>
                <xsl:otherwise>
                  <td> <xsl:value-of select="count(probe[month='08'])"/> </td>
                </xsl:otherwise>
              </xsl:choose>
              
              <!-- ...........................9- 12..........................................-->
              <xsl:choose>
                <xsl:when test ="count(probe[month='09'])=0"><td>-</td></xsl:when>
                <xsl:otherwise>
                  <td> <xsl:value-of select="count(probe[month='09'])"/> </td>
                </xsl:otherwise>
              </xsl:choose>
              <xsl:choose>
                <xsl:when test ="count(probe[month='10'])=0"><td>-</td></xsl:when>
                <xsl:otherwise>
                  <td> <xsl:value-of select="count(probe[month='10'])"/> </td>
                </xsl:otherwise>
              </xsl:choose>
              <xsl:choose>
                <xsl:when test ="count(probe[month='11'])=0"><td>-</td></xsl:when>
                <xsl:otherwise>
                  <td> <xsl:value-of select="count(probe[month='11'])"/> </td>
                </xsl:otherwise>
              </xsl:choose>
              <xsl:choose>
                <xsl:when test ="count(probe[month='12'])=0"><td>-</td></xsl:when>
                <xsl:otherwise>
                  <td> <xsl:value-of select="count(probe[month='12'])"/> </td>
                </xsl:otherwise>
              </xsl:choose>
            </tr>
          </xsl:for-each>
        </table>
      </body>
    </html>
  </xsl:template>

</xsl:stylesheet>
