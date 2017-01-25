<root dataType="Struct" type="Duality.Resources.Scene" id="129723834">
  <assetInfo />
  <globalGravity dataType="Struct" type="Duality.Vector2">
    <X dataType="Float">0</X>
    <Y dataType="Float">33</Y>
  </globalGravity>
  <serializeObj dataType="Array" type="Duality.GameObject[]" id="427169525">
    <item dataType="Struct" type="Duality.GameObject" id="3044615015">
      <active dataType="Bool">true</active>
      <children />
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="2649896005">
        <_items dataType="Array" type="Duality.Component[]" id="2882122966" length="4">
          <item dataType="Struct" type="Duality.Components.Transform" id="1109962651">
            <active dataType="Bool">true</active>
            <angle dataType="Float">0</angle>
            <angleAbs dataType="Float">0</angleAbs>
            <angleVel dataType="Float">0</angleVel>
            <angleVelAbs dataType="Float">0</angleVelAbs>
            <deriveAngle dataType="Bool">true</deriveAngle>
            <gameobj dataType="ObjectRef">3044615015</gameobj>
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
          <item dataType="Struct" type="Duality.Components.Camera" id="3581890822">
            <active dataType="Bool">true</active>
            <farZ dataType="Float">10000</farZ>
            <focusDist dataType="Float">500</focusDist>
            <gameobj dataType="ObjectRef">3044615015</gameobj>
            <nearZ dataType="Float">0</nearZ>
            <passes dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Components.Camera+Pass]]" id="1409674666">
              <_items dataType="Array" type="Duality.Components.Camera+Pass[]" id="2737342496" length="4">
                <item dataType="Struct" type="Duality.Components.Camera+Pass" id="95628252">
                  <clearColor dataType="Struct" type="Duality.Drawing.ColorRgba" />
                  <clearDepth dataType="Float">1</clearDepth>
                  <clearFlags dataType="Enum" type="Duality.Drawing.ClearFlag" name="All" value="3" />
                  <input />
                  <matrixMode dataType="Enum" type="Duality.Drawing.RenderMatrix" name="PerspectiveWorld" value="0" />
                  <output dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.RenderTarget]]" />
                  <visibilityMask dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="AllGroups" value="2147483647" />
                </item>
                <item dataType="Struct" type="Duality.Components.Camera+Pass" id="1440557334">
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
              <_version dataType="Int">2</_version>
            </passes>
            <perspective dataType="Enum" type="Duality.Drawing.PerspectiveMode" name="Parallax" value="1" />
            <visibilityMask dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="All" value="4294967295" />
          </item>
          <item dataType="Struct" type="Duality.Plugins.Companion.Samples.AutoScroller" id="673545169">
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">3044615015</gameobj>
          </item>
        </_items>
        <_size dataType="Int">3</_size>
        <_version dataType="Int">3</_version>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="271202344" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="3385025583">
            <item dataType="Type" id="2729498350" value="Duality.Components.Transform" />
            <item dataType="Type" id="3199249866" value="Duality.Components.Camera" />
            <item dataType="Type" id="3326153950" value="Duality.Plugins.Companion.Samples.AutoScroller" />
          </keys>
          <values dataType="Array" type="System.Object[]" id="3196729248">
            <item dataType="ObjectRef">1109962651</item>
            <item dataType="ObjectRef">3581890822</item>
            <item dataType="ObjectRef">673545169</item>
          </values>
        </body>
      </compMap>
      <compTransform dataType="ObjectRef">1109962651</compTransform>
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="3329493181">4mELYnL7cUKRVSx6l8pn9A==</data>
        </header>
        <body />
      </identifier>
      <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
      <name dataType="String">Camera</name>
      <parent />
      <prefabLink />
    </item>
    <item dataType="Struct" type="Duality.GameObject" id="372974443">
      <active dataType="Bool">false</active>
      <children />
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="3337534233">
        <_items dataType="Array" type="Duality.Component[]" id="104950094" length="4">
          <item dataType="Struct" type="Duality.Plugins.Companion.Drawing.CheckeredBackground" id="3354814937">
            <_x003C_ColorTint_x003E_k__BackingField dataType="Struct" type="Duality.Drawing.ColorRgba">
              <A dataType="Byte">255</A>
              <B dataType="Byte">255</B>
              <G dataType="Byte">255</G>
              <R dataType="Byte">255</R>
            </_x003C_ColorTint_x003E_k__BackingField>
            <_x003C_Z_x003E_k__BackingField dataType="Float">500</_x003C_Z_x003E_k__BackingField>
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">372974443</gameobj>
          </item>
        </_items>
        <_size dataType="Int">1</_size>
        <_version dataType="Int">1</_version>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="2090866560" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="3269791283">
            <item dataType="Type" id="973201958" value="Duality.Plugins.Companion.Drawing.CheckeredBackground" />
          </keys>
          <values dataType="Array" type="System.Object[]" id="1273325752">
            <item dataType="ObjectRef">3354814937</item>
          </values>
        </body>
      </compMap>
      <compTransform />
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="464148569">u2KwbItaREG5PSAYRKKulA==</data>
        </header>
        <body />
      </identifier>
      <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
      <name dataType="String">CheckeredBackground</name>
      <parent />
      <prefabLink />
    </item>
    <item dataType="Struct" type="Duality.GameObject" id="3770853638">
      <active dataType="Bool">true</active>
      <children />
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="236967888">
        <_items dataType="Array" type="Duality.Component[]" id="1966828220" length="4">
          <item dataType="Struct" type="Duality.Components.Transform" id="1836201274">
            <active dataType="Bool">true</active>
            <angle dataType="Float">0</angle>
            <angleAbs dataType="Float">0</angleAbs>
            <angleVel dataType="Float">0</angleVel>
            <angleVelAbs dataType="Float">0</angleVelAbs>
            <deriveAngle dataType="Bool">true</deriveAngle>
            <gameobj dataType="ObjectRef">3770853638</gameobj>
            <ignoreParent dataType="Bool">false</ignoreParent>
            <parentTransform />
            <pos dataType="Struct" type="Duality.Vector3" />
            <posAbs dataType="Struct" type="Duality.Vector3" />
            <scale dataType="Float">1</scale>
            <scaleAbs dataType="Float">1</scaleAbs>
            <vel dataType="Struct" type="Duality.Vector3" />
            <velAbs dataType="Struct" type="Duality.Vector3" />
          </item>
          <item dataType="Struct" type="Duality.Plugins.Companion.Drawing.PlaneRenderer" id="756135127">
            <_x003C_ColorTint_x003E_k__BackingField dataType="Struct" type="Duality.Drawing.ColorRgba">
              <A dataType="Byte">255</A>
              <B dataType="Byte">13</B>
              <G dataType="Byte">13</G>
              <R dataType="Byte">240</R>
            </_x003C_ColorTint_x003E_k__BackingField>
            <_x003C_CustomMaterial_x003E_k__BackingField dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]" />
            <_x003C_Material_x003E_k__BackingField dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
              <contentPath dataType="String">Data\Graphics\arrow.Material.res</contentPath>
            </_x003C_Material_x003E_k__BackingField>
            <_x003C_Offset_x003E_k__BackingField dataType="Struct" type="Duality.Vector2" />
            <_x003C_Scrolling_x003E_k__BackingField dataType="Enum" type="Duality.Plugins.Companion.Drawing.PlaneRenderer+ScrollingMode" name="Horiziontal" value="0" />
            <_x003C_ScrollingMultiplier_x003E_k__BackingField dataType="Float">1</_x003C_ScrollingMultiplier_x003E_k__BackingField>
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">3770853638</gameobj>
          </item>
        </_items>
        <_size dataType="Int">2</_size>
        <_version dataType="Int">6</_version>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="3193496174" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="323014818">
            <item dataType="ObjectRef">2729498350</item>
            <item dataType="Type" id="362280720" value="Duality.Plugins.Companion.Drawing.PlaneRenderer" />
          </keys>
          <values dataType="Array" type="System.Object[]" id="1239005962">
            <item dataType="ObjectRef">1836201274</item>
            <item dataType="ObjectRef">756135127</item>
          </values>
        </body>
      </compMap>
      <compTransform dataType="ObjectRef">1836201274</compTransform>
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="295070034">/+g81P62XkGlyYIAap7opw==</data>
        </header>
        <body />
      </identifier>
      <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
      <name dataType="String">PlaneRenderer</name>
      <parent />
      <prefabLink />
    </item>
    <item dataType="Struct" type="Duality.GameObject" id="3869338925">
      <active dataType="Bool">true</active>
      <children />
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="1093919775">
        <_items dataType="Array" type="Duality.Component[]" id="2185709934" length="4">
          <item dataType="Struct" type="Duality.Components.Transform" id="1934686561">
            <active dataType="Bool">true</active>
            <angle dataType="Float">0</angle>
            <angleAbs dataType="Float">0</angleAbs>
            <angleVel dataType="Float">0</angleVel>
            <angleVelAbs dataType="Float">0</angleVelAbs>
            <deriveAngle dataType="Bool">true</deriveAngle>
            <gameobj dataType="ObjectRef">3869338925</gameobj>
            <ignoreParent dataType="Bool">false</ignoreParent>
            <parentTransform />
            <pos dataType="Struct" type="Duality.Vector3">
              <X dataType="Float">0</X>
              <Y dataType="Float">0</Y>
              <Z dataType="Float">500</Z>
            </pos>
            <posAbs dataType="Struct" type="Duality.Vector3">
              <X dataType="Float">0</X>
              <Y dataType="Float">0</Y>
              <Z dataType="Float">500</Z>
            </posAbs>
            <scale dataType="Float">1</scale>
            <scaleAbs dataType="Float">1</scaleAbs>
            <vel dataType="Struct" type="Duality.Vector3" />
            <velAbs dataType="Struct" type="Duality.Vector3" />
          </item>
          <item dataType="Struct" type="Duality.Plugins.Companion.Drawing.PlaneRenderer" id="854620414">
            <_x003C_ColorTint_x003E_k__BackingField dataType="Struct" type="Duality.Drawing.ColorRgba">
              <A dataType="Byte">255</A>
              <B dataType="Byte">234</B>
              <G dataType="Byte">10</G>
              <R dataType="Byte">10</R>
            </_x003C_ColorTint_x003E_k__BackingField>
            <_x003C_CustomMaterial_x003E_k__BackingField dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]" />
            <_x003C_Material_x003E_k__BackingField dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
              <contentPath dataType="String">Data\Graphics\alpha.Material.res</contentPath>
            </_x003C_Material_x003E_k__BackingField>
            <_x003C_Offset_x003E_k__BackingField dataType="Struct" type="Duality.Vector2" />
            <_x003C_Scrolling_x003E_k__BackingField dataType="Enum" type="Duality.Plugins.Companion.Drawing.PlaneRenderer+ScrollingMode" name="Horiziontal" value="0" />
            <_x003C_ScrollingMultiplier_x003E_k__BackingField dataType="Float">1</_x003C_ScrollingMultiplier_x003E_k__BackingField>
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">3869338925</gameobj>
          </item>
        </_items>
        <_size dataType="Int">2</_size>
        <_version dataType="Int">2</_version>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="1376370720" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="4115159957">
            <item dataType="ObjectRef">2729498350</item>
            <item dataType="ObjectRef">362280720</item>
          </keys>
          <values dataType="Array" type="System.Object[]" id="4100016328">
            <item dataType="ObjectRef">1934686561</item>
            <item dataType="ObjectRef">854620414</item>
          </values>
        </body>
      </compMap>
      <compTransform dataType="ObjectRef">1934686561</compTransform>
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="3685020319">iSpqHcu/9EepLkQoK6raUA==</data>
        </header>
        <body />
      </identifier>
      <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
      <name dataType="String">PlaneRenderer</name>
      <parent />
      <prefabLink />
    </item>
  </serializeObj>
  <visibilityStrategy dataType="Struct" type="Duality.Components.DefaultRendererVisibilityStrategy" id="2035693768" />
</root>
<!-- XmlFormatterBase Document Separator -->
