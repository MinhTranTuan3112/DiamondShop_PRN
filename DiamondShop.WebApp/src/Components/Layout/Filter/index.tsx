import { useState } from "react";
import FilterIcon from "../../../assets/icons/filter.svg";
import "./style.css";

export default function Filter() {
  const FilterList = [
    {
      category: "Category",
      options: ["Lifestyle", "Sport", "Culture"],
    },
    {
      category: "Gender",
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
      category: "Status",
      options: ["Available", "NonAvailable"],
    },
  ];

  const [selectedFilter, setselectedFilter] = useState([""]);
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

  function handleSelectFilter(option: string) {
    const temp = [...selectedFilter.filter((item) => item !== ""), option];
    console.log(temp);
    setselectedFilter(temp);
  }

  function handleReset() {
    setCurSelect("");
    setselectedFilter([""]);
  }
  return (
    <>
      <div
        style={{
          height: "100px",
          display: "flex",
          alignItems: "center",
          justifyContent: "center",
        }}
      >
        <div className="filter-desk">
          <button
            onClick={() => handleOpenFilter()}
            className={openFilter ? "filter-toggle static" : "filter-toggle"}
          >
            <div className="filter-left">{openFilter ? "CLOSE" : "FILTER"}</div>
            <div className="filter-right">
              <img src={FilterIcon} className="filter-icon" />
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
                    <li
                      key={optionIndex}
                      className="filter-item"
                      onClick={() => handleSelectFilter(option)}
                    >
                      <a className="filter-select">{option}</a>
                    </li>
                  ))}
                </ul>
              </div>
            </div>
          ))}
          <div
            className={
              openFilter
                ? "filter-desk-category active"
                : "filter-desk-category"
            }
          >
            <div className="filter-desk-btn">
              <div className="filter-left" onClick={() => handleReset()}>
                Reset
              </div>
            </div>
          </div>
        </div>
      </div>
    </>
  );
}
