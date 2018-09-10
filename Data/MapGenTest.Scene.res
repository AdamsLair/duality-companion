<root dataType="Struct" type="Duality.Resources.Scene" id="129723834">
  <assetInfo />
  <globalGravity dataType="Struct" type="Duality.Vector2">
    <X dataType="Float">0</X>
    <Y dataType="Float">33</Y>
  </globalGravity>
  <serializeObj dataType="Array" type="Duality.GameObject[]" id="427169525">
    <item dataType="Struct" type="Duality.GameObject" id="2401007604">
      <active dataType="Bool">true</active>
      <children />
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="3836028490">
        <_items dataType="Array" type="Duality.Component[]" id="1737863520" length="4">
          <item dataType="Struct" type="Duality.Components.Transform" id="2458284822">
            <active dataType="Bool">true</active>
            <angle dataType="Float">0</angle>
            <angleAbs dataType="Float">0</angleAbs>
            <angleVel dataType="Float">0</angleVel>
            <angleVelAbs dataType="Float">0</angleVelAbs>
            <deriveAngle dataType="Bool">true</deriveAngle>
            <gameobj dataType="ObjectRef">2401007604</gameobj>
            <ignoreParent dataType="Bool">false</ignoreParent>
            <parentTransform />
            <pos dataType="Struct" type="Duality.Vector3">
              <X dataType="Float">0</X>
              <Y dataType="Float">0</Y>
              <Z dataType="Float">-500</Z>
            </pos>
            <posAbs dataType="Struct" type="Duality.Vector3">
              <X dataType="Float">0</X>
              <Y dataType="Float">0</Y>
              <Z dataType="Float">-500</Z>
            </posAbs>
            <scale dataType="Float">1</scale>
            <scaleAbs dataType="Float">1</scaleAbs>
            <vel dataType="Struct" type="Duality.Vector3" />
            <velAbs dataType="Struct" type="Duality.Vector3" />
          </item>
          <item dataType="Struct" type="Duality.Components.Camera" id="3947394081">
            <active dataType="Bool">true</active>
            <farZ dataType="Float">10000</farZ>
            <focusDist dataType="Float">500</focusDist>
            <gameobj dataType="ObjectRef">2401007604</gameobj>
            <nearZ dataType="Float">0</nearZ>
            <passes dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Components.Camera+Pass]]" id="3511976773">
              <_items dataType="Array" type="Duality.Components.Camera+Pass[]" id="418460886" length="4">
                <item dataType="Struct" type="Duality.Components.Camera+Pass" id="3713683744">
                  <clearColor dataType="Struct" type="Duality.Drawing.ColorRgba" />
                  <clearDepth dataType="Float">1</clearDepth>
                  <clearFlags dataType="Enum" type="Duality.Drawing.ClearFlag" name="All" value="3" />
                  <input />
                  <matrixMode dataType="Enum" type="Duality.Drawing.RenderMatrix" name="PerspectiveWorld" value="0" />
                  <output dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.RenderTarget]]" />
                  <visibilityMask dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="AllGroups" value="2147483647" />
                </item>
                <item dataType="Struct" type="Duality.Components.Camera+Pass" id="1622052750">
                  <clearColor dataType="Struct" type="Duality.Drawing.ColorRgba" />
                  <clearDepth dataType="Float">1</clearDepth>
                  <clearFlags dataType="Enum" type="Duality.Drawing.ClearFlag" name="None" value="0" />
                  <input />
                  <matrixMode dataType="Enum" type="Duality.Drawing.RenderMatrix" name="OrthoScreen" value="1" />
                  <output dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.RenderTarget]]" />
                  <visibilityMask dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="All" value="4294967295" />
                </item>
              </_items>
              <_size dataType="Int">2</_size>
            </passes>
            <perspective dataType="Enum" type="Duality.Drawing.PerspectiveMode" name="Parallax" value="1" />
            <priority dataType="Int">0</priority>
            <visibilityMask dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="All" value="4294967295" />
          </item>
        </_items>
        <_size dataType="Int">2</_size>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="1988397210" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="2944053040">
            <item dataType="Type" id="2127538876" value="Duality.Components.Transform" />
            <item dataType="Type" id="3614270102" value="Duality.Components.Camera" />
          </keys>
          <values dataType="Array" type="System.Object[]" id="3760005742">
            <item dataType="ObjectRef">2458284822</item>
            <item dataType="ObjectRef">3947394081</item>
          </values>
        </body>
      </compMap>
      <compTransform dataType="ObjectRef">2458284822</compTransform>
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="58350476">aBfhQpMqsEuWX1CsTPtNmQ==</data>
        </header>
        <body />
      </identifier>
      <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
      <name dataType="String">Camera</name>
      <parent />
      <prefabLink />
    </item>
    <item dataType="Struct" type="Duality.GameObject" id="2360625744">
      <active dataType="Bool">true</active>
      <children />
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="3856733430">
        <_items dataType="Array" type="Duality.Component[]" id="1496962272" length="8">
          <item dataType="Struct" type="Duality.Components.Transform" id="2417902962">
            <active dataType="Bool">true</active>
            <angle dataType="Float">0</angle>
            <angleAbs dataType="Float">0</angleAbs>
            <angleVel dataType="Float">0</angleVel>
            <angleVelAbs dataType="Float">0</angleVelAbs>
            <deriveAngle dataType="Bool">true</deriveAngle>
            <gameobj dataType="ObjectRef">2360625744</gameobj>
            <ignoreParent dataType="Bool">false</ignoreParent>
            <parentTransform />
            <pos dataType="Struct" type="Duality.Vector3" />
            <posAbs dataType="Struct" type="Duality.Vector3" />
            <scale dataType="Float">1</scale>
            <scaleAbs dataType="Float">1</scaleAbs>
            <vel dataType="Struct" type="Duality.Vector3" />
            <velAbs dataType="Struct" type="Duality.Vector3" />
          </item>
          <item dataType="Struct" type="Duality.Plugins.Tilemaps.Tilemap" id="1566271181">
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">2360625744</gameobj>
            <tileData dataType="Struct" type="Duality.Plugins.Tilemaps.TilemapData" id="1750910457" custom="true">
              <body>
                <version dataType="Int">3</version>
                <data dataType="Array" type="System.Byte[]" id="656250446">H4sIAAAAAAAEAO2XPUtCURjHr1QgF9py0AgCkaA1IuISLWXQ0MdIqKGhwcHBqSXsAxRYH6EPIOJUo05tmaObjg6S9vI7ywOHc869dW8GCvLjOW/+/885597Hdc/zVj6/y97XZzrH76AFGiAIiwqo6tYc6/qSlrvrf+MZtMOixiplIaJJ36KuTytXZsLkIbTcARiCaVjU+dkNoXONviWiksGfNhOqsRiD3Kj+CkJnxtlfnZGHRHmQpbGflAcTukhKET2J6Mrur8vIBZADZ+BiFvz1wAR0RHRj99cD9+AapJk+Ai3QABVQnQXvdbu/qe7GyTvWZEgR1Ggs/y9/6hqW7KuYRs79xfLsyRsqgfj9Rb2+at7YMOEB3IE0AkcJ+9Ne3x27+HcmeEQj+9IDMEzYn3Z6geiA6FJnU74YHsUpCECWVfp/ev+001XlcQReadwS4gNxoPfEVrXtOxbVnyoI8jotUtI+uBVJ1tZLqyAHjsGJONAZ50flD/2pguBNJFJCSdomOhVJ1tZLvoB8TsgNj+rPtCvup9xU0wa6rfJ12ATnwP2vggmmXXE/5aaa1g8LtY0vRKmwSY4RDkfYASqtHTBxT/IHhJaQYIgRAAA=</data>
              </body>
            </tileData>
            <tileset dataType="Struct" type="Duality.ContentRef`1[[Duality.Plugins.Tilemaps.Tileset]]">
              <contentPath dataType="String">Data\Graphics\TileCraftGroundSet.Tileset.res</contentPath>
            </tileset>
          </item>
          <item dataType="Struct" type="Duality.Plugins.Companion.MapGen.TilemapController" id="2658126058">
            <_emptyTileIndex dataType="Int">10</_emptyTileIndex>
            <_solidTileIndex dataType="Int">13</_solidTileIndex>
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">2360625744</gameobj>
          </item>
          <item dataType="Struct" type="Duality.Plugins.Companion.Samples.MapGenSample" id="3553395315">
            <_mapGenerationData dataType="Struct" type="Duality.Plugins.Companion.MapGen.MapGenerationData" id="2481339975">
              <_featureNum dataType="Int">20</_featureNum>
              <_height dataType="Int">20</_height>
              <_maxCorridorLength dataType="Int">10</_maxCorridorLength>
              <_maxIterations dataType="Int">100</_maxIterations>
              <_maxRoomSize dataType="Int">10</_maxRoomSize>
              <_minCorridorLength dataType="Int">2</_minCorridorLength>
              <_minRoomSize dataType="Int">3</_minRoomSize>
              <_width dataType="Int">32</_width>
            </_mapGenerationData>
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">2360625744</gameobj>
          </item>
          <item dataType="Struct" type="Duality.Plugins.Tilemaps.TilemapRenderer" id="3234658838">
            <active dataType="Bool">true</active>
            <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
              <A dataType="Byte">255</A>
              <B dataType="Byte">255</B>
              <G dataType="Byte">255</G>
              <R dataType="Byte">255</R>
            </colorTint>
            <externalTilemap />
            <gameobj dataType="ObjectRef">2360625744</gameobj>
            <offset dataType="Float">0</offset>
            <origin dataType="Enum" type="Duality.Alignment" name="Center" value="0" />
            <tileDepthMode dataType="Enum" type="Duality.Plugins.Tilemaps.TileDepthOffsetMode" name="Flat" value="0" />
            <tileDepthOffset dataType="Int">0</tileDepthOffset>
            <tileDepthScale dataType="Float">0.01</tileDepthScale>
            <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="Group0" value="1" />
          </item>
        </_items>
        <_size dataType="Int">5</_size>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="2092174874" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="65428420">
            <item dataType="Type" id="2177658180" value="Duality.Plugins.Tilemaps.Tilemap" />
            <item dataType="Type" id="2573890198" value="Duality.Plugins.Companion.MapGen.TilemapController" />
            <item dataType="Type" id="1582589184" value="Duality.Plugins.Companion.Samples.MapGenSample" />
            <item dataType="ObjectRef">2127538876</item>
            <item dataType="Type" id="2658499618" value="Duality.Plugins.Tilemaps.TilemapRenderer" />
          </keys>
          <values dataType="Array" type="System.Object[]" id="2324125078">
            <item dataType="ObjectRef">1566271181</item>
            <item dataType="ObjectRef">2658126058</item>
            <item dataType="ObjectRef">3553395315</item>
            <item dataType="ObjectRef">2417902962</item>
            <item dataType="ObjectRef">3234658838</item>
          </values>
        </body>
      </compMap>
      <compTransform dataType="ObjectRef">2417902962</compTransform>
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="1278652032">vYy5pQGrfUu9msTJw3g5IQ==</data>
        </header>
        <body />
      </identifier>
      <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
      <name dataType="String">MapGenSample</name>
      <parent />
      <prefabLink />
    </item>
    <item dataType="Struct" type="Duality.GameObject" id="1261108144">
      <active dataType="Bool">true</active>
      <children />
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="1554549014">
        <_items dataType="Array" type="Duality.Component[]" id="3198140704" length="4">
          <item dataType="Struct" type="Duality.Components.Transform" id="1318385362">
            <active dataType="Bool">true</active>
            <angle dataType="Float">0</angle>
            <angleAbs dataType="Float">0</angleAbs>
            <angleVel dataType="Float">0</angleVel>
            <angleVelAbs dataType="Float">0</angleVelAbs>
            <deriveAngle dataType="Bool">true</deriveAngle>
            <gameobj dataType="ObjectRef">1261108144</gameobj>
            <ignoreParent dataType="Bool">false</ignoreParent>
            <parentTransform />
            <pos dataType="Struct" type="Duality.Vector3" />
            <posAbs dataType="Struct" type="Duality.Vector3" />
            <scale dataType="Float">1</scale>
            <scaleAbs dataType="Float">1</scaleAbs>
            <vel dataType="Struct" type="Duality.Vector3" />
            <velAbs dataType="Struct" type="Duality.Vector3" />
          </item>
          <item dataType="Struct" type="Duality.Components.Renderers.TextRenderer" id="2144045798">
            <active dataType="Bool">true</active>
            <blockAlign dataType="Enum" type="Duality.Alignment" name="Center" value="0" />
            <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
              <A dataType="Byte">255</A>
              <B dataType="Byte">255</B>
              <G dataType="Byte">255</G>
              <R dataType="Byte">255</R>
            </colorTint>
            <customMat />
            <gameobj dataType="ObjectRef">1261108144</gameobj>
            <iconMat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]" />
            <offset dataType="Int">-10</offset>
            <text dataType="Struct" type="Duality.Drawing.FormattedText" id="229564454">
              <flowAreas />
              <fonts dataType="Array" type="Duality.ContentRef`1[[Duality.Resources.Font]][]" id="843892992">
                <item dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Font]]">
                  <contentPath dataType="String">Default:Font:GenericMonospace10</contentPath>
                </item>
              </fonts>
              <icons />
              <lineAlign dataType="Enum" type="Duality.Alignment" name="Left" value="1" />
              <maxHeight dataType="Int">0</maxHeight>
              <maxWidth dataType="Int">0</maxWidth>
              <sourceText dataType="String">Press Space to generate map</sourceText>
              <wrapMode dataType="Enum" type="Duality.Drawing.FormattedText+WrapMode" name="Word" value="1" />
            </text>
            <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="Group0" value="1" />
          </item>
        </_items>
        <_size dataType="Int">2</_size>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="775750618" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="2977864164">
            <item dataType="ObjectRef">2127538876</item>
            <item dataType="Type" id="844669380" value="Duality.Components.Renderers.TextRenderer" />
          </keys>
          <values dataType="Array" type="System.Object[]" id="698969110">
            <item dataType="ObjectRef">1318385362</item>
            <item dataType="ObjectRef">2144045798</item>
          </values>
        </body>
      </compMap>
      <compTransform dataType="ObjectRef">1318385362</compTransform>
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="1193799648">Ix8mF7dvyEGW4X5f3Ab+Dg==</data>
        </header>
        <body />
      </identifier>
      <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
      <name dataType="String">TextRenderer</name>
      <parent />
      <prefabLink />
    </item>
  </serializeObj>
  <visibilityStrategy dataType="Struct" type="Duality.Components.DefaultRendererVisibilityStrategy" id="2035693768" />
</root>
<!-- XmlFormatterBase Document Separator -->
