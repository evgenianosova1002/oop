<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

	<xsl:output method="html" encoding="UTF-8"/>

	<xsl:template match="/">
		<html>
			<body>
				<h2>Department Library Books</h2>
				<table border="1" cellpadding="4">
					<tr>
						<th>ID</th>
						<th>Author</th>
						<th>Title</th>
						<th>Department</th>
						<th>Faculty</th>
						<th>Qualification</th>
						<th>For Readers</th>
						<th>Position</th>
					</tr>

					<xsl:for-each select="library/book">
						<tr>
							<td>
								<xsl:value-of select="@id"/>
							</td>
							<td>
								<xsl:value-of select="author"/>
							</td>
							<td>
								<xsl:value-of select="title"/>
							</td>
							<td>
								<xsl:value-of select="@department"/>
							</td>
							<td>
								<xsl:value-of select="@faculty"/>
							</td>
							<td>
								<xsl:value-of select="@qualification"/>
							</td>
							<td>
								<xsl:value-of select="@forReaders"/>
							</td>
							<td>
								<xsl:value-of select="@position"/>
							</td>
						</tr>
					</xsl:for-each>

				</table>
			</body>
		</html>
	</xsl:template>

</xsl:stylesheet>
