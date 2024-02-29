// InteriorConfiguration.js
import React from "react";

function InteriorConfiguration() {
  return (
    <div>
      <h2>Interior Configuration</h2>
      <p>
        This is the interior configuration section. Here you can select options
        related to the interior features of the car.
      </p>
      <div>
        <label htmlFor="seats">Seats:</label>
        <select id="seats">
          <option value="leather">Leather</option>
          <option value="cloth">Cloth</option>
        </select>
      </div>
      <div>
        <label htmlFor="navigation">Navigation:</label>
        <select id="navigation">
          <option value="gps">GPS</option>
          <option value="maps">Maps</option>
        </select>
      </div>
    </div>
  );
}

export default InteriorConfiguration;
