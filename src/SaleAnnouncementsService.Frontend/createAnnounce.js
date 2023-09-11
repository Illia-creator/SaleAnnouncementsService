import axios from 'https://cdn.jsdelivr.net/npm/axios@1.3.5/+esm';


const App = {
    data(){
        return{
            windowTitle: "Create Announcement",

            title: "",
            description: "",
            price: 0,

            mainPhotoLink: "string",
            seckondPhotoLink: "string",
            thirdPhotoLink: "string",

            titleInstructions: "Enter Title ",
            descriptionInstructions: "Enter Description ",
            priceInstructions: "Enter Price ",

            titleMax: 200,
            descriptionMax: 1000,
            
            priceValidated: false
        }
    },

    methods: {
        createAnnouncement(){
            if(this.price >= 0){
                axios.post(`http://localhost:5072/api/Annoncements/create-announcement`,{
                    title: this.title,
                    description: this.description,
                    price: this.price,
                    mainPhotoLink: this.mainPhotoLink,
                    seckondPhotoLink: this.seckondPhotoLink,
                    thirdPhotoLink: this.thirdPhotoLink                  
                })
                .then(response => {
                    this.announcements = response.data
                })
                .catch(error => {
                    console.error(error)
                })

                this.goBack()

            }
            else{
                console.log("Price lower than 0: ", this.price)
            }

        },      

        goBack(){
            window.location.href = `index.html`
        }
       
    }

}

document.addEventListener('DOMContentLoaded', function () {
    const textarea = document.getElementById('myTextarea')
    const charCount = document.getElementById('charCount')
  
    textarea.addEventListener('input', function () {
      const length = this.value.length;
      charCount.textContent = `(${length}/200)`;
  
      if (length > this.titleMax) {
        charCount.classList.add('error')
        this.value = this.value.substring(0, this.titleMax)
      } else {
        charCount.classList.remove('error')
      }
    });
  });

  document.addEventListener('DOMContentLoaded', function () {
    const textarea = document.getElementById('myTextareaDescription')
    const charCount = document.getElementById('charCountDescription')
  
    textarea.addEventListener('input', function () {
      const length = this.value.length;
      charCount.textContent = `(${length}/1000)`
  
      if (length > this.titleMax) {
        charCount.classList.add('error')
        this.value = this.value.substring(0, this.titleMax)
      } else {
        charCount.classList.remove('error')
      }
    });
  });
 
Vue.createApp(App).mount('#app-div')