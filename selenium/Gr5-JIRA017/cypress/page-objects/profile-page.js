const LBL_USER = '//div[text()][following-sibling::div//a[text()="Edit profile"]]'
const BTN_EDIT = '//a[text()="Edit profile"]'

export const ProfilePage = {
    getProfilePageName() {
        return cy.xpath(LBL_USER)
    },

    clickEditProfile() {
        cy.xpath(BTN_EDIT).click()
    },

    checkUserProfilePage() {
        cy.xpath(LBL_USER).should('be.visible')
    }

}


