import React from "react";
import { useParams, useNavigate } from "react-router-dom";

function CustomizationButtons({
  onCoreClick,
  onStandardClick,
  onInteriorClick,
  onExteriorClick,
  onConfirmClick,
}) {
  const navigate = useNavigate();
  const { model_id, quantity } = useParams();

  const handleBackClick = () => {
    navigate(`/Defaultconfig/${model_id}/${quantity}`);
  };
  return (
    <div>
      <div className="button-row">
        <button className="button" onClick={onCoreClick}>
          Core
        </button>
        <button className="button" onClick={onStandardClick}>
          Standard
        </button>
        <button className="button" onClick={onInteriorClick}>
          Interior
        </button>
        <button className="button" onClick={onExteriorClick}>
          Exterior
        </button>
        <button className="button" onClick={handleBackClick}>
          Back
        </button>
        <button className="button" onClick={onConfirmClick}>
          Confirm
        </button>
      </div>
    </div>
  );
}

export default CustomizationButtons;
