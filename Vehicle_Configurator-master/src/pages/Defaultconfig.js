import React, { useState, useEffect } from "react";
import { useParams, Link, useNavigate } from "react-router-dom";
import "./DefaultConfiguration.css";
import InvoiceGenerator from "./InvoiceGenerator";

function Defaultconfig() {
  const { model_id, quantity } = useParams();
  const navigate = useNavigate();

  const [carDetails, setCarDetails] = useState({
    id: null,
    modelName: "",
    price: 0,
    segmentMaster: { id: null, name: "" },
    mfgMaster: { id: null, name: "" },
    imagePath: "",
  });

  const [standardFeatures, setStandardFeatures] = useState([]);
  const [coreFeatures, setCoreFeatures] = useState([]);
  const [interiorFeatures, setInteriorFeatures] = useState([]);
  const [exteriorFeatures, setExteriorFeatures] = useState([]);
  const [showInvoice, setShowInvoice] = useState(false);
  const [price, setPrice] = useState(0);

  useEffect(() => {
    const fetchCarDetails = async () => {
      try {
        const response = await fetch(`https://localhost:7139/api/Model/${model_id}`);
        const data = await response.json();
        setCarDetails(data);
        console.log(data); // Assuming the API returns an array with a single object
      } catch (error) {
        console.error("Error fetching car details:", error);
      }
    };

    const fetchStandardFeatures = async () => {
      try {
        const response = await fetch(`https://localhost:7139/api/VehicleDetail/ByStandard/${model_id}`);
        const data = await response.json();
        setStandardFeatures(data);
      } catch (error) {
        console.error("Error fetching standard features:", error);
      }
    };

    const fetchCoreFeatures = async () => {
      try {
        const response = await fetch(`https://localhost:7139/api/VehicleDetail/ByCore/${model_id}`);
        const data = await response.json();
        setCoreFeatures(data);
      } catch (error) {
        console.error("Error fetching core features:", error);
      }
    };

    const fetchInteriorFeatures = async () => {
      try {
        const response = await fetch(`https://localhost:7139/api/VehicleDetail/ByInterior/${model_id}`);
        const data = await response.json();
        setInteriorFeatures(data);
      } catch (error) {
        console.error("Error fetching interior features:", error);
      }
    };

    const fetchExteriorFeatures = async () => {
      try {
        const response = await fetch(`https://localhost:7139/api/VehicleDetail/ByExterior/${model_id}`);
        const data = await response.json();
        setExteriorFeatures(data);
      } catch (error) {
        console.error("Error fetching exterior features:", error);
      }
    };

    const fetchPrice = async () => {
      try {
        const response = await fetch(`https://localhost:7139/api/VehicleDetail/Price/${model_id}`);
        const data = await response.json();
        setPrice(data);
      } catch (error) {
        console.error("Error fetching price:", error);
      }
    };

    // Call all the fetch functions
    fetchCarDetails();
    fetchStandardFeatures();
    fetchCoreFeatures();
    fetchInteriorFeatures();
    fetchExteriorFeatures();
    fetchPrice();
  }, [model_id]);

  const handleConfigure = () => {
    navigate(`/Customize/${model_id}/${quantity}`); // Assuming "/configure" is the correct route
  };
  const handleConfirmOrder = () => {
    // Confirm order logic
    alert("Order confirmed!");
    setShowInvoice(true); // Set state to show InvoiceGenerator
  };
  return (
    <div>
      <div className="default-configuration">
        <div className="car-info">
          <img
            src={`/${carDetails.imagePath}`}
            alt="Car"
            className="car-image"
          />
          <div className="info">
            <h2>{`${carDetails.modelName}`}</h2>
            <p>
              Description of the car Lorem ipsum dolor sit amet, consectetur
              adipiscing elit. Nulla euismod ligula vel justo sodales, nec
              tincidunt orci ultricies.
            </p>

            <h4>Core Features:</h4>
            <ul>
              {coreFeatures.map((feature, index) => (
                <li key={index}>{feature.comp.compName}</li>
              ))}
            </ul>
            <h4>Standard Features:</h4>
            <ul>
              {standardFeatures.map((feature, index) => (
                <li key={index}>{feature.comp.compName}</li>
              ))}
            </ul>

            <h4>Interior Features:</h4>
            <ul>
              {interiorFeatures.map((feature, index) => (
                <li key={index}>{feature.comp.compName}</li>
              ))}
            </ul>

            <h4>Exterior Features:</h4>
            <ul>
              {exteriorFeatures.map((feature, index) => (
                <li key={index}>{feature.comp.compName}</li>
              ))}
            </ul>

            <h4>Price: {price}</h4>

            <div className="buttons">
            <button onClick={handleConfirmOrder}>Confirm</button>

              <button onClick={handleConfigure}>Configure</button>

              {/* Cancel button with Link for navigation */}
              <Link to="/home">
                <button>Cancel</button>
              </Link>
            </div>
          </div>
        </div>
      </div>
      {showInvoice && (
        <InvoiceGenerator
          orderSize={quantity}
          price={price}
          modelname={carDetails.modelName}
        />
      )}
    </div>
  );
}

export default Defaultconfig;
