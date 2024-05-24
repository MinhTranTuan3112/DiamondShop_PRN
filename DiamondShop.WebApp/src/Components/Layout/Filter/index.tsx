import { useState } from "react";
import { IoFilterSharp } from "react-icons/io5";
import "./style.css";

export default function Filter() {
  const FilterList = [
    {
      category: "Concept",
      options: ["Lifestyle", "Sport", "Culture"],
    },
    {
      category: "Range",
      options: ["Men", "Women"],
    },
    {
      category: "Type",
      options: ["Lifestyle", "Sport", "Culture"],
    },
    {
      category: "Material",
      options: ["Lifestyle", "Sport", "Culture"],
    },
    {
      category: "Color",
      options: ["Lifestyle", "Sport", "Culture"],
    },
  ];
  const [openFilter, setOpenFilter] = useState(false);
  const [curSelect, setCurSelect] = useState("");

  const tempSelect = curSelect;
  function handleOpenSelect(item: string) {
    setCurSelect(tempSelect === item ? "" : item);
  }

  function handleOpenFilter() {
    setOpenFilter(!openFilter);
    setCurSelect("");
  }

  return (
    <>
      <div className="filter-desk">
        <button
          onClick={() => handleOpenFilter()}
          className={openFilter ? "filter-toggle static" : "filter-toggle"}
        >
          <div className="filter-left">FILTERS</div>
          <div className="filter-right">
            <IoFilterSharp className="filter-icon" />
          </div>
        </button>

        {FilterList.map((filter, index) => (
          <div
            key={index}
            className={
              openFilter
                ? "filter-desk-category active"
                : "filter-desk-category"
            }
          >
            <div
              className="filter-desk-btn"
              onClick={() => handleOpenSelect(filter.category)}
            >
              <div className="filter-left">{filter.category}</div>
              <div className="filter-right">All</div>
            </div>
            <div
              className={
                curSelect === filter.category
                  ? "filter-desk-option active"
                  : "filter-desk-option"
              }
            >
              <ul className="filter-list">
                {filter.options.map((option, optionIndex) => (
                  <li key={optionIndex} className="filter-item">
                    <a href="" className="filter-select">
                      {option}
                    </a>
                  </li>
                ))}
              </ul>
            </div>
          </div>
        ))}
        <div
          className={
            openFilter ? "filter-desk-category active" : "filter-desk-category"
          }
        >
          <div className="filter-desk-btn">
            <div className="filter-left" onClick={() => setCurSelect("")}>
              Reset
            </div>
          </div>
        </div>
      </div>
    </>
  );
}
