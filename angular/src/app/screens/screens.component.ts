import { Component, Injector } from '@angular/core';
import { MatDialog } from '@angular/material';
import { finalize } from 'rxjs/operators';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {
    PagedListingComponentBase,
    PagedRequestDto
} from '@shared/paged-listing-component-base';
import {
    ScreenServiceProxy,
    ScreenDto,
    PagedResultDtoOfScreenDto
} from '@shared/service-proxies/service-proxies';
import { CreateScreenDialogComponent } from './create-screen/create-screen-dialog.component';
import { EditScreenDialogComponent } from './edit-screen/edit-screen-dialog.component';

class PagedScreensRequestDto extends PagedRequestDto {
    keyword: string;
}

@Component({
    templateUrl: './screens.component.html',
    animations: [appModuleAnimation()],
    styles: [
        `
          mat-form-field {
            padding: 10px;
          }
        `
    ]
})
export class ScreensComponent extends PagedListingComponentBase<ScreenDto> {
    screens: ScreenDto[] = [];

    keyword = '';

    constructor(
        injector: Injector,
        private _screensService: ScreenServiceProxy,
        private _dialog: MatDialog
    ) {
        super(injector);
    }

    list(
        request: PagedScreensRequestDto,
        pageNumber: number,
        finishedCallback: Function
    ): void {

        request.keyword = this.keyword;

        this._screensService
            .getAll(request.keyword, request.skipCount, request.maxResultCount)
            .pipe(
                finalize(() => {
                    finishedCallback();
                })
            )
            .subscribe((result: PagedResultDtoOfScreenDto) => {
                this.screens = result.items;
                this.showPaging(result, pageNumber);
            });
    }

    delete(screen: ScreenDto): void {
        abp.message.confirm(
            this.l('ScreenDeleteWarningMessage', screen.name),
            (result: boolean) => {
                if (result) {
                    this._screensService
                        .delete(screen.id)
                        .pipe(
                            finalize(() => {
                                abp.notify.success(this.l('SuccessfullyDeleted'));
                                this.refresh();
                            })
                        )
                        .subscribe(() => { });
                }
            }
        );
    }

    createScreen(): void {
        this.showCreateOrEditScreenDialog();
    }

    editScreen(screen: ScreenDto): void {
        this.showCreateOrEditScreenDialog(screen.id);
    }

    showCreateOrEditScreenDialog(id?: number): void {
        let createOrEditScreenDialog;
        if (id === undefined || id <= 0) {
            createOrEditScreenDialog = this._dialog.open(CreateScreenDialogComponent);
        } else {
            createOrEditScreenDialog = this._dialog.open(EditScreenDialogComponent, {
                data: id
            });
            //createOrEditScreenDialog.componentInstance.screenId = id;
        }

        createOrEditScreenDialog.afterClosed().subscribe(result => {
            if (result) {
                this.refresh();
            }
        });
    }
}
