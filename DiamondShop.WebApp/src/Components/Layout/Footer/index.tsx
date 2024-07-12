import "./style.css";
import { FaXTwitter } from "react-icons/fa6";
import { FaFacebookF, FaLinkedin, FaInstagram } from "react-icons/fa";

import FooterIcon from "../../../assets/icons/icon.png";

export default function Footer() {
  return (
    <>
      <footer className="footer">
        <div className="row">
          <div className="column">
            <img src={FooterIcon} alt="" className="footer-icon" />
            <p className="desc">
              Pure Perfection in Every Carat. Sparkle with Every Moment.
            </p>
            <div className="socials">
              <a
                target="blank"
                href="https://www.facebook.com/profile.php?id=100021014582039"
              >
                <FaFacebookF className="icon" />
              </a>
              <a href="https://www.instagram.com/sword.1111/" target="blank">
                <FaInstagram className="icon" />
              </a>
              <a target="blank" href="">
                <FaLinkedin className="icon" />
              </a>
              <a target="blank" href="">
                <FaXTwitter className="icon" />
              </a>
            </div>
          </div>
          <div className="column">
            <h3 className="title">Legal</h3>
            <ul className="list">
              <li>
                <a href="#!">Privacy</a>
              </li>
              <li>
                <a href="#!">Policy</a>
              </li>
              <li>
                <a href="#!">Terms</a>
              </li>
              <li>
                <a href="#!">Cookie Policy</a>
              </li>
            </ul>
          </div>
          <div className="column">
            <h3 className="title">Careers</h3>
            <ul className="list">
              <li>
                <a href="">Careers Portal</a>
              </li>
              <li>
                <a href="">Tech Blog</a>
              </li>
            </ul>
          </div>
          <div className="column">
            <h3 className="title">Address</h3>
            <ul className="list">
              <li>
                <a href="">
                  <strong>Location:</strong> 27 Division St, New York, NY 10002,
                  USA
                </a>
              </li>
              <li>
                <a href="">Email: email@gmail.com</a>
              </li>
              <li>
                <a href="">
                  <strong>Phone:</strong> + 000 1234 567 890
                </a>
              </li>
            </ul>
          </div>
        </div>
        <div className="copyright">
          <p>Copyright ©2024 MAPTH All rights reserved</p>
        </div>
      </footer>
    </>
  );
}
