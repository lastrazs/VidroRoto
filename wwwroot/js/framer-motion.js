// framer-motion.js
import { motion } from 'framer-motion';

window.animateTitle = () => {
  const title = document.getElementById("animated-title");

  title.style.opacity = 0;
  title.style.transform = "translateY(-20px)";

  setTimeout(() => {
    title.style.transition = "all 0.5s ease";
    title.style.opacity = 1;
    title.style.transform = "translateY(0)";
  }, 100);  // Delay para simular la animación
};
